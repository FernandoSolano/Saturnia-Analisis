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
        private User leader;
        private LinkedList<User> collaborators;

        public Project()
        {
            leader = new User();
            collaborators = new LinkedList<User>();
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public bool State { get => state; set => state = value; }
        public string Description { get => description; set => description = value; }
        public User Leader { get => leader; set => leader = value; }
        public LinkedList<User> Collaborators { get => collaborators; set => collaborators = value; }
    }
}
