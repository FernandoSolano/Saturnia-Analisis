using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Domain
{
    public class User
    {
        private int id;
        private String name, nickname, password;
        private Role role;

        public User()
        {
            role = new Role();
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Nickname { get => nickname; set => nickname = value; }
        public string Password { get => password; set => password = value; }
        public Role Role { get => role; set => role = value; }
    }
}
