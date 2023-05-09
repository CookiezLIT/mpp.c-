using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace MPP_Problema1.Model
{
    [Table("public.user")]
    public class User
    {
        private User() { }
        public User(string name, string password)
        {
            Id = Guid.NewGuid().ToString();
            Name = name;
            Password = password;
        }

        public User(Guid id, string name, string password)
        {
            Id = id.ToString();
            Name = name;
            Password = password;
        }

        public User(IDataReader reader)
        {
            this.Id = (string)reader["id"];
            this.Name = (string)reader["name"];
            this.Password = (string)reader["password"];
        }

        public User(object id, object name, object password)
        {
            this.Id = ((Guid)id).ToString();
            this.Name = (string)name;
            this.Password = (string)password;
        }

        [Column("id")]
        [Key]
        public string Id { get; private set; }

        [Column("name")]
        public string Name { get; private set; }

        [Column("password")]
        public string Password { get; private set; }
    }
}
