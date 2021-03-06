﻿using WebAPIStarterTemplate.Core.Models;
using WebAPIStarterTemplate.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace WebAPIStarterTemplate.Data.Repositories
{
    public class ProjectRepository : Repository<Project>, IProjectRepository
    {

        private WebAPIStarterTemplateDbContext WebAPIStarterTemplateDbContext
        {
            get { return Context as WebAPIStarterTemplateDbContext; }
        }


        public ProjectRepository(WebAPIStarterTemplateDbContext context)
            : base(context) { }


        public IEnumerable<ProjectTask> GetAllByTasks(int taskId)
        {
            throw new NotImplementedException();
        }
    }
}


