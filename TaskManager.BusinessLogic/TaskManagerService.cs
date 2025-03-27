using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager_BusinessDataLogic
{
    public class TaskManagerService
    {
        private TaskRepository taskRepo = new TaskRepository();

        public string[] GetTasks() => taskRepo.GetTasks();

        public bool AddTask(string task) => taskRepo.AddTask(task);

        public bool RemoveTask(int taskNumber) => taskRepo.RemoveTask(taskNumber - 1);
    }
}
