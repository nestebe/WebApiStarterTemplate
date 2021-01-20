using System;
using System.Collections.Generic;
using System.Text;

namespace WebAPIStarterTemplate.Core.Models
{
    public class ProjectTask
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public Project Project { get; set; }
        public int ProjectId { get; set; }

    }
}
