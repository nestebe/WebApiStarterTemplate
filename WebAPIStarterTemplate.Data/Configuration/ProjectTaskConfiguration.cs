using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebAPIStarterTemplate.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebAPIStarterTemplate.Data.Configuration
{
    public class ProjectTaskConfiguration:IEntityTypeConfiguration<ProjectTask>
    {

        public void Configure(EntityTypeBuilder<ProjectTask> builder)
        {
            builder.HasKey(t => t.Id);


            builder
                .HasOne(t => t.Project)
                .WithMany(q => q.Tasks)
                .HasForeignKey(t => t.ProjectId);

            builder.ToTable("ProjectTasks");
        }

    }
}
