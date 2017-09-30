using System;

namespace Core.Domain
{
    public class Role
    {
        private int id;
        private String name, description;

        public Role()
        {
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Description { get => description; set => description = value; }
    }
}
