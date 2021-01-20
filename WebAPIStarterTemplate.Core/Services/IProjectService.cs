using WebAPIStarterTemplate.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAPIStarterTemplate.Core.Services
{
    public interface IProjectService
    {
        Task<Project> GetProjectById(int id);
        Task<IEnumerable<Project>> GetAllProjects();
        Task<Project> CreateProject(Project newProject);
        Task UpdateProject(Project projectToUpdate, Project project);
        Task DeleteProject(Project project);

    }
}
