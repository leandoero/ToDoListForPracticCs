/*
 Что сделать:
Создайте приложение для управления задачами (TODO-лист). Пользователь может:

Добавлять задачи.
Помечать их как выполненные.
Удалять задачи.
Сохранять и загружать список из файла.
 */

using ToDoListForPracticC_.Services;
using ToDoListForPracticC_.Models;
using System;
using ToDoListForPracticC_.EntityFramework;
using static System.Runtime.InteropServices.JavaScript.JSType;
bool flag = true;
var TaskService = new TaskService();
ApplicationContext db = new ApplicationContext();
int use = 0;
do
{
    Console.Clear();
    Console.WriteLine("1. Load data from databaseuse\n2. New data");
    Console.Write("Input: ");
    string input = Console.ReadLine();
    if (!int.TryParse(input, out use))
    {
        continue;
    }
} while (use != 1 && use != 2);

if(use == 1)
{
    TaskService.AddTasksFromBDtoList(db);
}

while (flag)
{
    Console.Clear();
    Console.WriteLine("=== TODO list ===");
    Console.WriteLine();
    string multiLine = "1. Add task\n2. Mark completed\n3. Delete task\n4. Print tasks\n5. Add tasks to BD\n6. Exit\n";
    Console.WriteLine(multiLine);
    int choice;

    Console.Write("Input: ");
    string input = Console.ReadLine();
    if (!int.TryParse(input, out choice))
    {   
        continue;
    }
    if (choice < 1 || choice > 6)
    {
        continue;
    }
    switch (choice)
    {
        case 1:
            {
                Console.Write("\nTask Names: ");
                string taskName = Console.ReadLine();

                var TaskItem = new TaskItem(TaskService.getTasksCount() + 1, taskName);
                TaskService.addTasks(TaskItem);
                break;
            }
        case 2:
            {
                
                int taskID = 0;
                Console.Write("\nTask ID: ");
                while (true)
                {
                    string _input = Console.ReadLine();
                    if (!int.TryParse(_input, out taskID))
                    {
                        Console.WriteLine("Error");
                    }
                    else
                    {
                        break;
                    }

                }
                TaskService.markTask(taskID);
                break;
            }
        case 3:
            {
                int taskID = 0;
                Console.Write("\nTask ID: ");
                while (true)
                {
                    string _input = Console.ReadLine();
                    if (!int.TryParse(_input, out taskID))
                    {
                        Console.WriteLine("Error");
                    }
                    else
                    {
                        break;
                    }

                }
                TaskService.removeTasks(taskID);
                TaskService.ReassignIDs();
                break;
            }
        case 4:
            {
                TaskService.printTasks();
                Console.WriteLine();
                Console.ReadKey();
                Console.Write("press something to continue");
                
                string index;
                if (TaskService.tasksIsCompleted())
                {
                    do
                    {
                        index = Console.ReadLine();
                        Console.WriteLine("Delete completed tasks? Y/N");
                    } while (index != "Y" && index != "N");
                    if(index == "Y")
                    {
                        TaskService.removeTasksCompleted();
                        TaskService.ReassignIDs();
                    }
                }
                break;
            }
        case 5:
            {
                db.RemoveRange(db.itemsDb);
                db.SaveChanges();
                TaskService.AddTasksToDB(db);
                db.SaveChanges();
                break;
            }
        case 6:
            {
                Console.Write("bye");
                flag = false;
                break;
                
            }
    }
}


