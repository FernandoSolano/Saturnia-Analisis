using Core.Data;
using Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Core.Business
{
    public class TaskBusiness
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

        public void DeleteTask(Task task)
        {
            this.taskData.DeleteTask(task);
        }

        public Task GetHoursByDateAndCollaborator(Task task)
        {
            return taskData.GetHoursByDateAndCollaborator(task);
        }


        public Task ShowTask(Task task)
        {
            return taskData.ShowTask(task);
        }

        public void UpdateTask(Task task)
        {
            this.taskData.UpdateTask(task);
        }

    }
}
