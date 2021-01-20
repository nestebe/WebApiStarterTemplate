using WebAPIStarterTemplate.Core;
using WebAPIStarterTemplate.Core.Repositories;
using WebAPIStarterTemplate.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WebAPIStarterTemplate.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly WebAPIStarterTemplateDbContext _context;
        private IProjectTaskRepository _timeRepository;
        private IProjectRepository _projectRepository;
        private IUserRepository _userRepository;

        public UnitOfWork(WebAPIStarterTemplateDbContext context)
        {
            this._context = context;
        }

        public IProjectTaskRepository ProjectTasks => _timeRepository = _timeRepository ?? new ProjectTaskRepository(_context);
        public IProjectRepository Projects => _projectRepository = _projectRepository ?? new ProjectRepository(_context);
        public IUserRepository Users => _userRepository = _userRepository ?? new UserRepository(_context);

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
