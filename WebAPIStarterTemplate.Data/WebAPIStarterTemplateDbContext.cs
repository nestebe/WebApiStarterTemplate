using Microsoft.EntityFrameworkCore;
using WebAPIStarterTemplate.Core.Models;
using WebAPIStarterTemplate.Data.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebAPIStarterTemplate.Data
{
    public class WebAPIStarterTemplateDbContext : DbContext
    {
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectTask> ProjectTasks { get; set; }

        public WebAPIStarterTemplateDbContext(DbContextOptions<WebAPIStarterTemplateDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .ApplyConfiguration(new ProjectTaskConfiguration());

            builder
                .ApplyConfiguration(new ProjectConfiguration());

        }


    }
}
