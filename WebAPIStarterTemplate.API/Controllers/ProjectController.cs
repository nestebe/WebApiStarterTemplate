using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIStarterTemplate.API.Ressources;
using WebAPIStarterTemplate.API.Validation;
using WebAPIStarterTemplate.Core.Models;
using WebAPIStarterTemplate.Core.Services;

namespace WebAPIStarterTemplate.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;
        private readonly IMapper _mapperService;
        public ProjectController(IProjectService projectService, IMapper mapperService)
        {
            _projectService = projectService;
            _mapperService = mapperService;
        }

        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<ProjectRessource>>> GetAllProject()
        {
            try
            {
                var projects = await _projectService.GetAllProjects();
                var projectRessouces = _mapperService.Map<IEnumerable<Project>, IEnumerable<ProjectRessource>>(projects);

                return Ok(projectRessouces);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<ProjectRessource>>> GetProjectById(int id)
        {
            try
            {
                var project = await _projectService.GetProjectById(id);
                if (project == null) return NotFound();
                var projectRessouce = _mapperService.Map<Project, ProjectRessource>(project);

                return Ok(projectRessouce);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost()]
        public async Task<ActionResult<IEnumerable<ProjectRessource>>> CreateProject(SaveProjectRessource saveProjectRessource)
        {
            try
            {
                //Validation
                var validation = new SaveProjectRessourceValidation();
                var validationResult = await validation.ValidateAsync(saveProjectRessource);
                if (!validationResult.IsValid) return BadRequest(validationResult.Errors);

                //Mapping
                var project = _mapperService.Map<SaveProjectRessource, Project>(saveProjectRessource);
                //Commit to database
                var projectCreated = await _projectService.CreateProject(project);
                //Mapping return ressource
                var projectRessource = _mapperService.Map<Project, ProjectRessource>(projectCreated);

                return Ok(projectRessource);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
