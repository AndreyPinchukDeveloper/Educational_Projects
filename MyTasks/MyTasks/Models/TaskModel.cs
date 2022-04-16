using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTasks.Models
{
    class TaskModel
    {
        private bool _isDone;
        private string _text;

        public DateTime CreationData { get; set; } = DateTime.Now;

        public bool IsDone
        {
            get { return _isDone; }
            set { _isDone = value; }
        }
        public string Text
        {
            get { return _text; }
            set { _text = value; }
        }


    }
}
