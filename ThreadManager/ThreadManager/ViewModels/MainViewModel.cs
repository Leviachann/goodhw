using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading;
using System.Windows.Input;
using ThreadApp.Models;

namespace ThreadApp.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private ThreadViewModel selectedThread;
        private ObservableCollection<ThreadViewModel> inactiveThreads;
        private ObservableCollection<ThreadViewModel> processingThreads;

        public event PropertyChangedEventHandler PropertyChanged;

        public MainViewModel()
        {
            // Initialize collections
            inactiveThreads = new ObservableCollection<ThreadViewModel>();
            processingThreads = new ObservableCollection<ThreadViewModel>();

            // Create some initial inactive threads
            for (int i = 1; i <= 5; i++)
            {
                var threadModel = new ThreadModel()
                {
                    Name = $"Thread {i}",
                    Status = ThreadStatus.Inactive
                };
                var threadViewModel = new ThreadViewModel(threadModel); // Pass the threadModel as a parameter
                inactiveThreads.Add(threadViewModel);
            }
        }


        public ObservableCollection<ThreadViewModel> InactiveThreads
        {
            get { return inactiveThreads; }
            set
            {
                inactiveThreads = value;
                OnPropertyChanged("InactiveThreads");
            }
        }

        public ObservableCollection<ThreadViewModel> ProcessingThreads
        {
            get { return processingThreads; }
            set
            {
                processingThreads = value;
                OnPropertyChanged("ProcessingThreads");
            }
        }

        public ThreadViewModel SelectedThread
        {
            get { return selectedThread; }
            set
            {
                selectedThread = value;
                OnPropertyChanged("SelectedThread");
            }
        }

        public ICommand AddThreadCommand => new RelayCommand(AddThread);
        public ICommand PlayThreadCommand => new RelayCommand(PlayThread);
        public ICommand PauseThreadCommand => new RelayCommand(PauseThread);
        public ICommand ResumeThreadCommand => new RelayCommand(ResumeThread);
        public ICommand StopThreadCommand => new RelayCommand(StopThread);

        private void AddThread(object parameter)
        {
            // Add a new thread to the inactive list
            var threadModel = new ThreadModel()
            {
                Name = "New Thread",
                Status = ThreadStatus.Inactive
            };
            var threadViewModel = new ThreadViewModel(threadModel);
            inactiveThreads.Add(threadViewModel);
        }


        private void PlayThread(object parameter)
        {
            if (selectedThread != null && selectedThread.Status == ThreadStatus.Inactive)
            {
                // Move the selected thread from the inactive list to the processing list
                inactiveThreads.Remove(selectedThread);
                processingThreads.Add(selectedThread);
                selectedThread.Status = ThreadStatus.Playing;

                // Start the thread
                selectedThread.Thread = new Thread(() => ThreadMethod(selectedThread));
                selectedThread.Thread.Start();
            }
        }


        private void PauseThread(object parameter)
        {
            if (selectedThread != null && selectedThread.Status == ThreadStatus.Playing)
            {
                // Pause the selected thread
                selectedThread.Status = ThreadStatus.Paused;
            }
        }

        private void ResumeThread(object parameter)
        {
            if (selectedThread != null && selectedThread.Status == ThreadStatus.Paused)
            {
                // Resume the selected thread
                selectedThread.Status = ThreadStatus.Playing;
            }
        }

        private void StopThread(object parameter)
        {
            if (selectedThread != null)
            {
                // Stop and remove the selected thread from the processing list
                if (selectedThread.Status == ThreadStatus.Playing)
                    selectedThread.Thread.Abort(); // This is not recommended in general, but for simplicity in this example
                processingThreads.Remove(selectedThread);

                // Reset the thread's status and move it back to the inactive list
                selectedThread.Status = ThreadStatus.Inactive;
                inactiveThreads.Add(selectedThread);

                // Clear the selected thread
                selectedThread = null;
            }
        }

        private void ThreadMethod(ThreadViewModel thread)
        {
            // Simulate some work
            for (int i = 1; i <= 10; i++)
            {
                // Check if the thread should be paused or stopped
                if (thread.Status == ThreadStatus.Paused)
                {
                    // Wait until the thread is resumed
                    while (thread.Status == ThreadStatus.Paused)
                    {
                        Thread.Sleep(100);
                    }
                }
                else if (thread.Status == ThreadStatus.Inactive)
                {
                    // The thread has been stopped, so exit the loop
                    return;
                }

                // Simulate some work
                Thread.Sleep(1000);
            }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class RelayCommand : ICommand
    {
        private readonly Action<object> execute;
        private readonly Func<object, bool> canExecute;

        public event EventHandler CanExecuteChanged;

        public RelayCommand(Action<object> execute)
            : this(execute, null)
        {
        }

        public RelayCommand(Action<object> execute, Func<object, bool> canExecute)
        {
            this.execute = execute ?? throw new ArgumentNullException("execute");
            this.canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return canExecute == null || canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            execute(parameter);
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
}
}
