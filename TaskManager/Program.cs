using System;
using System.Runtime.CompilerServices;
using TaskManager_BusinessDataLogic;

namespace TaskManagerApp
{
    internal class Program
    {
        static void Main()
        {
            TaskManagerUI ui = new TaskManagerUI();
            ui.Run();
        }
    }

    class TaskManagerUI
    {
        private TaskManagerService taskService = new TaskManagerService();

        public void Run()
        {
            Console.WriteLine("TASK MANAGER");
            bool isRunning = true;

            while (isRunning)
            {
                DisplayMenuOptions();

                if (!int.TryParse(Console.ReadLine(), out int selectedOption))
                {
                    Console.WriteLine("Not a valid operation!\nChoose only in the options.");
                    continue;
                }

                switch (selectedOption)
                {
                    case 1:
                        DisplayTasks();
                        break;
                    case 2:
                        Console.Write("Enter task: ");
                        string task = Console.ReadLine();
                        if (taskService.AddTask(task))
                            Console.WriteLine("Task added.");
                        else
                            Console.WriteLine("Task list full.");
                        break;
                    case 3:
                        Console.Write("Enter task number to delete: ");

                        if (!int.TryParse(Console.ReadLine(), out int taskNumber))
                        {
                            Console.WriteLine("Invalid task number.\nChoose a number in the list only!");
                            break;
                        }

                        if (!taskService.RemoveTask(taskNumber))
                        {
                            Console.WriteLine("Invalid task number.\nChoose a number in the list only!");
                        }
                        else
                        {
                            Console.WriteLine("Task deleted.");
                        }
                        break;
                    case 4:
                        Console.WriteLine("Hope you did your tasks!");
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Not a valid operation!\nChoose only in the options.");
                        break;
                }
            }
        }

        private void DisplayTasks()
        {
            var tasks = taskService.GetTasks();
            Console.WriteLine("\nTASKS:");
            if (tasks.Length == 0)
            {
                Console.WriteLine("No tasks.");
                return;
            }
            for (int i = 0; i < tasks.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {tasks[i]}");
            }
        }

        private void DisplayMenuOptions()
        {
            Console.WriteLine("\nOPTIONS:");
            Console.WriteLine("1 - View Tasks");
            Console.WriteLine("2 - Add Task");
            Console.WriteLine("3 - Delete Task");
            Console.WriteLine("4 - Exit");
            Console.Write("Enter option: ");
        }
    }
}