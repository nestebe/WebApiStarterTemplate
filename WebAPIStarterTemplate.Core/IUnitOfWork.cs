using WebAPIStarterTemplate.Core.Repositories;
using System;
using System.Threading.Tasks;

namespace WebAPIStarterTemplate.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IProjectTaskRepository ProjectTasks { get; }
        IProjectRepository Projects { get; }
        IUserRepository Users { get; }
        Task<int> CommitAsync();

    }
}
