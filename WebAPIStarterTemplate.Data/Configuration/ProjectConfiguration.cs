using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebAPIStarterTemplate.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebAPIStarterTemplate.Data.Configuration
{
    class ProjectConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.ToTable("Projects");
        }
    }
}
