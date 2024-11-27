using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

using ToDoListForPracticC_.Models;

namespace ToDoListForPracticC_.Services
{
    //Содержит бизнес-логику приложения, например, добавление, удаление или обновление задач.
    internal class TaskService
    {
        private List<TaskItem> tasks = new List<TaskItem>();

        public int getTasksCount()
        {
            return tasks.Count;
        }
        public bool tasksIsCompleted()
        {
            foreach (var taskItem in tasks)
            {
                if (taskItem.IsCompleted)
                {
                    return true;
                }
            }
            return false;
        }
        public void addTasks(TaskItem taskitem)
        {
            tasks.Add(taskitem);
        }
        public void removeTasks(int id)
        {
            for (int i = 0; i < tasks.Count; i++)
            {
                if (tasks[i].Id == id)
                {
                    tasks.Remove(tasks[i]);
                    break;
                }
            }
        }
        public void removeTasksCompleted()
        {
            for (int i = 0; i < tasks.Count; i++)
            {
                if (tasks[i].IsCompleted)
                {
                    tasks.Remove(tasks[i]);
                }
            }
        }
        public void ReassignIDs()
        {
            for (int i = 0; i < tasks.Count; i++)
            {
                tasks[i].Id = i + 1;
            }
        }
        public void markTask(int id)
        {
            for (int i = 0; i < tasks.Count; i++)
            {
                if (tasks[i].Id == id)
                {
                    tasks[i].IsCompleted = true;

                    break;
                }
            }
        }
        public void printTasks()
        {
            
            foreach (var taskitem in tasks)
            {
                if (taskitem.IsCompleted == true)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    string outputForCompleted = taskitem.printItem();
                    Console.WriteLine(outputForCompleted);
                    Console.ResetColor();
                }
                else
                {
                    string output = taskitem.printItem();
                    Console.WriteLine(output);
                }
            }
        }
    }
}
