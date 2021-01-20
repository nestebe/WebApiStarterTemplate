using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace WebAPIStarterTemplate.Core.Models
{
    public class Project
    {
        public Project()
        {
            Tasks = new Collection<ProjectTask>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsDone { get; set; }
        public Collection<ProjectTask> Tasks { get; set; }
    }
}
