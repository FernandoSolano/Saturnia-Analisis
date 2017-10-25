using Core.Data;
using Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Core.Business
{
    class TaskBusiness
    {

        private TaskData taskData;

        public TaskBusiness()
        {
            this.taskData = new TaskData();
        }

        public Task addTask(Task task)
        {
            return taskData.AddTask(task);
        }

        public void DeleteTask(Task task)
        {
            this.taskData.DeleteTask(task);
        }

        }
}
