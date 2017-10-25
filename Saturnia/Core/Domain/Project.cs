using System;

namespace Core.Domain
{
    public class Project
    {
        private int id;
        private String name;
        private Boolean state;
        private String description;
        private int estimatedHours;
        private DateTime startDate;
        private DateTime endDate;

        public Project()
        {
            name = "";
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public bool State { get => state; set => state = value; }
        public string Description { get => description; set => description = value; }
        public int EstimatedHours { get => estimatedHours; set => estimatedHours = value; }
        public DateTime StartDate { get => startDate; set => startDate = value; }
        public DateTime EndDate { get => endDate; set => endDate = value; }
    }
}
