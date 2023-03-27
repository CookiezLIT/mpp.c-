using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace MPP_Problema1.Model
{
    [Table("public.user")]
    public class User
    {
        public User(string name, string password)
        {
            Id = Guid.NewGuid();
            Name = name;
            Password = password;
        }

        public User(Guid id, string name, string password)
        {
            Id = id;
            Name = name;
            Password = password;
        }

        public User(IDataReader reader)
        {
            this.Id = (Guid)reader["id"];
            this.Name = (string)reader["name"];
            this.Password = (string)reader["password"];
        }

        public User(object id, object name, object password)
        {
            this.Id = (Guid)id;
            this.Name = (string)name;
            this.Password = (string)password;
        }

        [Column("id")]
        public Guid Id { get; }

        [Column("name")]
        public string Name { get; }

        [Column("password")]
        public string Password { get; }
    }
}
