using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebAPIStarterTemplate.Core.Models;

namespace WebAPIStarterTemplate.Core.Services
{
    public interface  IUserService
    {
        Task<User> Authenticate(string username, string password);
        Task<User> Create(User user, string password);
        void Update(User user, string password = null);
        void Delete(int id);
        Task<IEnumerable<User>> GetAllUser();
        Task<User> GetUserById(int id);

    }
}
