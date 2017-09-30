using System;

namespace Core.Domain
{
    public class Task
    {
        private int id;
        private float hours;
        private Boolean extraHours;
        private DateTime date;
        private String description;
        private User collaborator;
        private Project project;
        private Category category;

        public Task()
        {
            collaborator = new User();
            project = new Project();
            category = new Category();
        }

        public int Id { get => id; set => id = value; }
        public float Hours { get => hours; set => hours = value; }
        public bool ExtraHours { get => extraHours; set => extraHours = value; }
        public DateTime Date { get => date; set => date = value; }
        public string Description { get => description; set => description = value; }
        public User Collaborator { get => collaborator; set => collaborator = value; }
        public Project Project { get => project; set => project = value; }
        public Category Category { get => category; set => category = value; }
    }
}
