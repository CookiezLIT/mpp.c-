using MPP_Problema1.Model;
using MPP_Problema1.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPP_Problema1.Service
{
    public class UserService
    {
        public UserRepository UserRepository { get; set; }
        public UserService(UserRepository repo) {
            this.UserRepository = repo;
        }

        public bool LogIn(string username, string password)
        {
            username.Remove(0);
            username.Remove(username.Length-1);
            password.Remove(0);
            password.Remove(password.Length-1);

            User user = new User(username, password);
            return this.UserRepository.isUser(user);
        }

        public User Register(string username, string password)
        {
            User user = new User(username, password);
            return this.UserRepository.Create(user);
        }
    }
}
