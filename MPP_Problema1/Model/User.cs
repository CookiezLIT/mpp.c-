using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPP_Problema1.Model
{
    public class User
    {
        public User(string name, string password)
        {
            Id = Guid.NewGuid();
            Name = name;
            Password = password;
        }

        public Guid Id { get; }

        public string Name { get; }

        public string Password { get; }

        
    }
}
