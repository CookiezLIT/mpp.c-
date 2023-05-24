using MPP_Problema1.Model;
using MPP_Problema1.Repository;
using System;
using System.ComponentModel.Composition.Hosting;
using System.Linq;

namespace MPP_Problema1.Service
{
    public class UserService
    {
        
        public UserService()
        {

        }

        //public UserService(UserRepository repo) {
        //    this.UserRepository = repo;
        //}

        public bool LogInAsync(string username, string password)
        {
            using (var db = new UserContext())
            {
                var exists = db.Users.Any(u => u.Name == username && u.Password == password);
                Console.Write(username + " " + password);
                return exists;
            }
        }

        public User Register(string username, string password)
        {
            using (var db = new UserContext())
            {
                User user = new User(username, password);
                db.Users.Add(user);
                db.SaveChanges();
                return user;
            }
        }
    }
}
