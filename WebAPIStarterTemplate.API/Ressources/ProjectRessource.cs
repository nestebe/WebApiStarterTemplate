using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using WebAPIStarterTemplate.Core.Models;

namespace WebAPIStarterTemplate.API.Ressources
{
    public class ProjectRessource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsDone { get; set; }
        public Collection<ProjectTaskRessource> Tasks { get; set; }



    }
}
