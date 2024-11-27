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
bool flag = true;
var TaskService = new TaskService();
while (flag)
{
    Console.Clear();
    Console.WriteLine("=== TODO list ===");
    Console.WriteLine();
    string multiLine = "1. Add task\n2. Mark completed\n3. Delete task\n4. Print tasks\n5. Exit\n";
    Console.WriteLine(multiLine);
    int choice;

    Console.Write("Input: ");
    string input = Console.ReadLine();
    if (!int.TryParse(input, out choice))
    {   
        continue;
    }
    if (choice < 1 || choice > 5)
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
                break;
            }
        case 4:
            {
                TaskService.printTasks();
                Console.WriteLine();
                Console.Write("press something to continue");
                Console.ReadKey();
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
                Console.Write("bye");
                flag = false;
                break;
            }
    }
}


