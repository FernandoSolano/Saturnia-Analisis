using System;
using System.Collections.Generic;

namespace Core.Domain
{
    public class User
    {
        private int id;
        private String firstName, lastName, nickname, password;
        private Role role;
        private LinkedList<Project> project;

        public User()
        {
            role = new Role();
            project = new LinkedList<Project>();
        }

        public int Id { get => id; set => id = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string Nickname { get => nickname; set => nickname = value; }
        public string Password { get => password; set => password = value; }
        public Role Role { get => role; set => role = value; }
        public LinkedList<Project> Project { get => project; set => project = value; }
    }
}
