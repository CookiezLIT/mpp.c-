
using model;

namespace ConsoleApp1.model
{
    [Serializable]
    public class User : Entity<int>
    {
        public String Name { get; set; }
        public String Password { get; set; }

        public User()
        {
        }

        public User(int id, string password)
            : this(id, "", password) { }

        public User(int id, string name, string password)
        {
            id = id;
            Name = name;
            Password = password;
        }
    }
}