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

        public Task AddTask(Task task)
        {
            return taskData.AddTask(task);
        }

        public float GetHoursByDateAndCollaborator(Task task)
        {
            return taskData.GetHoursByDateAndCollaborator(task);
        }

        public Task ShowTask(Task task)
        {
            return taskData.ShowTask(task);
        }

    }
}
