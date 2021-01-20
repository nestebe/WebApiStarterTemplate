using WebAPIStarterTemplate.Core;
using WebAPIStarterTemplate.Core.Models;
using WebAPIStarterTemplate.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WebAPIStarterTemplate.Services.Services
{
    public class ProjectTaskService : IProjectTaskService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProjectTaskService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ProjectTask> CreateProjectTask(ProjectTask newProjectTask)
        {
            await _unitOfWork.ProjectTasks.AddAsync(newProjectTask);
            await _unitOfWork.CommitAsync();
            return newProjectTask;
        }

        public async Task DeleteProjectTask(ProjectTask time)
        {
            _unitOfWork.ProjectTasks.Remove(time);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<ProjectTask>> GetAllProjectTasks()
        {
            return await _unitOfWork.ProjectTasks.GetAllAsync();
        }

        public async Task<ProjectTask> GetProjectTaskById(int id)
        {
            return await _unitOfWork.ProjectTasks.GetByIdAsync(id);
           
        }

        public async Task UpdateProjectTask(ProjectTask timeToUpdate, ProjectTask time)
        {
            timeToUpdate.Name = time.Name;
            timeToUpdate.Description = time.Description;
            timeToUpdate.Project = time.Project;
            timeToUpdate.ProjectId = time.ProjectId;
            timeToUpdate.StartTime = time.StartTime;
            timeToUpdate.EndTime = time.EndTime;
            await _unitOfWork.CommitAsync();
        }

   
    }
}
