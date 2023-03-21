using MPP_Problema1.Model;
using System.Threading.Tasks;

namespace MPP_Problema1.Service
{
    public class UserService
    {
        //public UserRepository UserRepository { get; set; }

        public readonly DatabaseContext _dbContext;

        public UserService(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        //public UserService(UserRepository repo) {
        //    this.UserRepository = repo;
        //}

        public async Task<bool> LogInAsync(string username, string password)
        {
            User user = new User(username, password);
            //return this.UserRepository.isUser(user);

            return await _dbContext.UserExistsAsync(user);

        }

        public async Task<User> Register(string username, string password)
        {
            User user = new User(username, password);
            return await _dbContext.CreateAsync(user);
        }
    }
}
