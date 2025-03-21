using System;

namespace TaskManager
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("TASK MANAGER");

            // Sample tasks
            string[] taskList = new string[5]
            {
                "Buy groceries",
                "Pay bills",
                "Do laundry",
                "Clean house",
                "Wash Dishes"
            };
            int taskCount = 5;

            bool isRunning = true;
            while (isRunning)
            {
                DisplayMenuOptions();

                int selectedOption = ParseUserSelection();
                if (selectedOption == 0) continue; 

                switch (selectedOption)
                {
                    case 1:
                        DisplayTaskList(taskList, taskCount);
                        break;
                    case 2:
                        if (CreateNewTask(taskList, ref taskCount))
                        {
                            Console.WriteLine("Task added.");
                        }
                        break;
                    case 3:
                        if (RemoveExistingTask(taskList, ref taskCount))
                        {
                            Console.WriteLine("Task deleted.");
                        }
                        break;
                    case 4:
                        Console.WriteLine("Hope you did your tasks!");
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }
        }

        static void DisplayMenuOptions()
        {
            Console.WriteLine("\nOPTIONS:");
            Console.WriteLine("1 - View Tasks");
            Console.WriteLine("2 - Add Task");
            Console.WriteLine("3 - Delete Task");
            Console.WriteLine("4 - Exit");
            Console.Write("Enter option: ");
        }

        static int ParseUserSelection()
        {
            try
            {
                return Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Invalid input. Try again.");
                return 0;
            }
        }

  
        static void DisplayTaskList(string[] taskList, int taskCount)
        {
            Console.WriteLine("\nTASKS:");

            if (taskCount == 0)
            {
                Console.WriteLine("No tasks.");
                return;
            }

            for (int i = 0; i < taskCount; i++)
            {
                Console.WriteLine($"{i + 1}. {taskList[i]}");
            }
        }

     
        static bool CreateNewTask(string[] taskList, ref int taskCount)
        {
            
            if (taskCount >= taskList.Length)
            {
                Console.WriteLine("Task list full.");
                return false;
            }

            Console.Write("Enter task: ");
            string newTask = Console.ReadLine();

            
            if (string.IsNullOrWhiteSpace(newTask))
            {
                Console.WriteLine("Task cannot be empty.");
                return false;
            }

            taskList[taskCount] = newTask;
            taskCount++;
            return true;
        }

        static bool RemoveExistingTask(string[] taskList, ref int taskCount)
        {
            
            if (taskCount == 0)
            {
                Console.WriteLine("No tasks to delete.");
                return false;
            }

            Console.Write("Enter task number to delete: ");

            
            int taskNumber;
            try
            {
                taskNumber = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Invalid input.");
                return false;
            }

           
            if (taskNumber < 1 || taskNumber > taskCount)
            {
                Console.WriteLine("Invalid task number.");
                return false;
            }

            
            ReorganizeTasksAfterRemoval(taskList, taskNumber - 1, taskCount);
            taskCount--;
            return true;
        }

     
        static void ReorganizeTasksAfterRemoval(string[] taskList, int removedIndex, int taskCount)
        {
            
            if (removedIndex < 0 || removedIndex >= taskCount)
            {
                return;
            }

            
            for (int i = removedIndex; i < taskCount - 1; i++)
            {
                taskList[i] = taskList[i + 1];
            }
        }
    }
}

/*
 Refactored the whole code to make it more readable and maintainable

Key Improvements

1.) Split functionality into dedicated methods instead of keeping everything in Main
 
- Each operation (display, add, delete) has its own method

2.) Used better data structure

- Replaced individual variables with an array to store tasks

3.) Added proper error handling

- Methods check for problems before proceeding
- Return values indicate success/failure

4.) Improved naming

- Used descriptive verb-noun names (CreateNewTask, RemoveExistingTask)
- Consistent naming patterns throughout the code

Methods Summary

DisplayMenuOptions: Displays the menu choices   
ParseUserSelection: Gets and validates user input
DisplayTaskList: Shows all current tasks
CreateNewTask: Adds a new task if there's room
RemoveExistingTask: Deletes a task and handles validation
ReorganizeTasksAfterRemoval: Shifts tasks to fill gaps after deletion
 
 */