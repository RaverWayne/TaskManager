using System;

namespace TaskManager
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("TASK MANAGER");

            // Task Manager program that allows user to view, add, and delete tasks

            // example task list
            string task1 = "Buy Groceries";
            string task2 = "Pay Bills";
            string task3 = "Do Laundry";
            string task4 = "Clean House";
            string task5 = "Wash Dishes";
            int taskCount = 5;

            while (true)
            {
                Console.WriteLine("\nOPTIONS:");
                Console.WriteLine("1 - View Tasks");
                Console.WriteLine("2 - Add Task");
                Console.WriteLine("3 - Delete Task");
                Console.WriteLine("4 - Exit");
                Console.Write("Enter option: ");

                int choice = Convert.ToInt16(Console.ReadLine());

                switch (choice)
                {
                    // View tasks
                    case 1:
                        Console.WriteLine("\nTASKS:");
                        if (taskCount == 0)
                        {
                            Console.WriteLine("No tasks.");
                        }
                        else
                        {
                            if (taskCount >= 1) Console.WriteLine($"1. {task1}");
                            if (taskCount >= 2) Console.WriteLine($"2. {task2}");
                            if (taskCount >= 3) Console.WriteLine($"3. {task3}");
                            if (taskCount >= 4) Console.WriteLine($"4. {task4}");
                            if (taskCount >= 5) Console.WriteLine($"5. {task5}");
                        }
                        break;
                    // Add task
                    case 2:
                        if (taskCount < 5)
                        {
                            Console.Write("Enter task: ");
                            string newTask = Console.ReadLine();

                            taskCount++;
                            if (taskCount == 1) task1 = newTask;
                            if (taskCount == 2) task2 = newTask;
                            if (taskCount == 3) task3 = newTask;
                            if (taskCount == 4) task4 = newTask;
                            if (taskCount == 5) task4 = newTask;

                            Console.WriteLine("Task added.");
                        }
                        else
                        {
                            Console.WriteLine("Task list full.");
                        }
                        break;
                    // Delete task
                    case 3:
                        Console.Write("Enter task number to delete: ");
                        int taskNum = Convert.ToInt32(Console.ReadLine());

                        if (taskNum >= 1 && taskNum <= taskCount)
                        {
                            if (taskNum == 1)
                            {
                                task1 = task2;
                                task2 = task3;
                                task3 = task4;
                                task4 = task5;
                            }
                            else if (taskNum == 2)
                            {
                                task2 = task3;
                                task3 = task4;
                                task4 = task5;
                            }
                            else if (taskNum == 3)
                            {
                                task3 = task4;
                                task4 = task5;
                            }
                            else if (taskNum == 4)
                            {
                                task4 = task5;
                            }

                            taskCount--;
                            Console.WriteLine("Task deleted.");
                        }
                        else
                        {
                            Console.WriteLine("Invalid task number.");
                        }
                        break;

                    case 4: // Exit
                        Console.WriteLine("Hope you did your tasks!");
                        return;

                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }
        }
    }
}