using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIStarterTemplate.API.Ressources
{
    public class ProjectTaskRessource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public ProjectRessource Project { get; set; }
        public int ProjectId { get; set; }

    }
}
