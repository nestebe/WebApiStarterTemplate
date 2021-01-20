using WebAPIStarterTemplate.Core;
using WebAPIStarterTemplate.Core.Models;
using WebAPIStarterTemplate.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WebAPIStarterTemplate.Services.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProjectService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Project> CreateProject(Project newProject)
        {
            await _unitOfWork.Projects.AddAsync(newProject);
            await _unitOfWork.CommitAsync();
            return newProject;
        }

        public async Task DeleteProject(Project project)
        {
            _unitOfWork.Projects.Remove(project);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Project>> GetAllProjects()
        {
            return await _unitOfWork.Projects.GetAllAsync();
        }

        public async Task<Project> GetProjectById(int id)
        {
            return await _unitOfWork.Projects.GetByIdAsync(id);
        }

        public async Task UpdateProject(Project projectToUpdate, Project project)
        {
            projectToUpdate.Tasks = project.Tasks;
            projectToUpdate.IsDone = project.IsDone;
            projectToUpdate.Name = project.Name;
            await _unitOfWork.CommitAsync();
        }
    }
}
