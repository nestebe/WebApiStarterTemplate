using WebAPIStarterTemplate.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WebAPIStarterTemplate.Core.Repositories
{
    public interface IProjectTaskRepository : IRepository<ProjectTask>
    {
        //specific operations
        IEnumerable<ProjectTask> GetAllByProject(int projectId);
    }
}
