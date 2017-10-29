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

        public Task addTask(Task task)
        {
            return taskData.AddTask(task);
        }


        public float GetHoursByDateAndCollaborator(Task task)
        {
            return taskData.GetHoursByDateAndCollaborator(task);

        public void updateTask(Task task)
        {
             taskData.updateTask(task);

        }
    }
}
