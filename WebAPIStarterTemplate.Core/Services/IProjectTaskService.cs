using WebAPIStarterTemplate.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WebAPIStarterTemplate.Core.Services
{
    public interface IProjectTaskService
    {
        Task<ProjectTask> GetProjectTaskById(int id);
        Task<IEnumerable<ProjectTask>> GetAllProjectTasks();
        Task<ProjectTask> CreateProjectTask(ProjectTask newProjectTask);
        Task UpdateProjectTask(ProjectTask timeToUpdate, ProjectTask time);
        Task DeleteProjectTask(ProjectTask time);
    }
}
