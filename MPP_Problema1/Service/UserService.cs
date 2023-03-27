using MPP_Problema1.Model;
using MPP_Problema1.Repository;
using SimpleSql;
using System.Linq;
using System.Threading.Tasks;

namespace MPP_Problema1.Service
{
    public class UserService
    {
        //public UserRepository UserRepository { get; set; }

        public readonly IRepository<User> _repo;

        public UserService(IRepository<User> repo)
        {
            _repo = repo;
        }

        //public UserService(UserRepository repo) {
        //    this.UserRepository = repo;
        //}

        public async Task<bool> LogInAsync(string username, string password)
        {
            var users = await _repo.GetAllAsync();

            //return this.UserRepository.isUser(user);

            return users.Any(x => x.Name == username && x.Password == password);


        }

        public async Task<User> Register(string username, string password)
        {
            User user = new User(username, password);
            return await _repo.CreateAsync(user);
        }
    }
}
