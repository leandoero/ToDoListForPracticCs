using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//Эта папка содержит классы, описывающие данные. Например, класс TaskItem будет представлять задачу.
namespace ToDoListForPracticC_.Models
{
    internal class TaskItem
    {
        private int _id;
        private string _name;
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public string Name {
            get { return _name; }
            set { _name = value; }
        }
        public bool IsCompleted { get; set; } = false;

        public TaskItem(int id, string name)
        {
            _id = id;
            _name = name;
        }

        public string printItem()
        {
            return "ID: " + _id + " Title: " + _name;
        }

    }
}
