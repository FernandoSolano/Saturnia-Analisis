using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Domain
{
    public class Project
    {
        private int id;
        private String name;
        private Boolean state;
        private String description;
        private String estimatedHours;
        private Datetime startDate;
        private Datetime endDate;

        public Project()
        {
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public bool State { get => state; set => state = value; }
        public string Description { get => description; set => description = value; }
        private string EstimatedHours { get => estimatedHours; set => estimatedHours = value; }
        private Datetime StartDate { get => startDate; set => startDate = value; }
        private Datetime EndDate { get => endDate; set => endDate = value; }
    }
}
