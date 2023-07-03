using System.ComponentModel;
using System.Threading;
using ThreadApp.Models;

namespace ThreadApp.ViewModels
{
    public class ThreadViewModel : INotifyPropertyChanged
    {
        private ThreadModel threadModel;

        public event PropertyChangedEventHandler PropertyChanged;

        public ThreadViewModel(ThreadModel threadModel)
        {
            this.threadModel = threadModel;
        }

        public string Name
        {
            get { return threadModel.Name; }
            set
            {
                threadModel.Name = value;
                OnPropertyChanged("Name");
            }
        }

        public ThreadStatus Status
        {
            get { return threadModel.Status; }
            set
            {
                threadModel.Status = value;
                OnPropertyChanged("Status");
            }
        }

        public Thread Thread
        {
            get { return threadModel.Thread; }
            set { threadModel.Thread = value; }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
