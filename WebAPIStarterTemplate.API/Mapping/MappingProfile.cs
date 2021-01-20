using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIStarterTemplate.API.Ressources;
using WebAPIStarterTemplate.Core.Models;

namespace WebAPIStarterTemplate.API.Mapping
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            //Mapping DATA => API Ressources
            CreateMap<Project, ProjectRessource>();
            CreateMap<ProjectTask, ProjectTaskRessource>();
            CreateMap<Project, SaveProjectRessource>();

            //Mapping API Ressources => DATA
            CreateMap<ProjectRessource, Project>();
            CreateMap<ProjectTaskRessource, ProjectTask>();
            CreateMap<SaveProjectRessource, Project>();
        }

    }
}
