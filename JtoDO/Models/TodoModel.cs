using System;
using System.ComponentModel;

namespace JtoDO.Models
{
    class TodoModel : INotifyPropertyChanged
    {
        public DateTime CreationTime { get; set; } = DateTime.Now;

        private bool isDo;

        public bool IsDone
        {
            get { return isDo; }
            set
            {
                if (isDo == value)
                    return;
   
                isDo = value;
                
                OnProperyChanged("IsDone");
            }
        }

        private string task;

        public string Task
        {
            get { return task; }
            set {
                if (task == value)
                    return;
                task = value;
                OnProperyChanged("Task");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnProperyChanged(string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


    }
}
