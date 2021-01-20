using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebAPIStarterTemplate.Core.Models;

namespace WebAPIStarterTemplate.Core.Repositories
{
    public interface IUserRepository 
    {

        Task<User> Authenticate(string username, string password);
        Task<User> Create(User user, string password);
        void Update(User user, string password =null);
        void Delete(int id);
        Task<IEnumerable<User>> GetAllUserAsync();
        Task<User> GetUserByIdAsync(int id);

    }
}
