using System.Threading;

namespace ThreadApp.Models
{
    public class ThreadModel
    {
        public string Name { get; set; }
        public ThreadStatus Status { get; set; }
        public Thread Thread { get; set; }
    }

    public enum ThreadStatus
    {
        Inactive,
        Playing,
        Paused
    }
}
