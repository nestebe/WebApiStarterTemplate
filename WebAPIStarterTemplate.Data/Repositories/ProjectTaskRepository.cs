using WebAPIStarterTemplate.Core.Models;
using WebAPIStarterTemplate.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPIStarterTemplate.Data.Repositories
{
    public class ProjectTaskRepository : Repository<ProjectTask>, IProjectTaskRepository
    {

        private WebAPIStarterTemplateDbContext WebAPIStarterTemplateDbContext
        {
            get { return Context as WebAPIStarterTemplateDbContext; }
        }


        public ProjectTaskRepository(WebAPIStarterTemplateDbContext context)
            : base(context) { }

        public IEnumerable<ProjectTask> GetAllByProject(int projectId)
        {
            return WebAPIStarterTemplateDbContext.ProjectTasks.Where(c => c.ProjectId.Equals(projectId));

        }
    }
}
