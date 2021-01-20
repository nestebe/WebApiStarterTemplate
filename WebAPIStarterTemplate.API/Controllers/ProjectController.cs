using AutoMapper;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
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
        public async Task<ActionResult<ProjectRessource>> CreateProject(SaveProjectRessource saveProjectRessource)
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

        [HttpPut("{id}")]
        public async Task<ActionResult<ProjectRessource>> UpdateProject(int id, SaveProjectRessource saveProjectRessource)
        {
            //Validation
            var validation = new SaveProjectRessourceValidation();
            var validationResult = await validation.ValidateAsync(saveProjectRessource);
            if (!validationResult.IsValid) return BadRequest(validationResult.Errors);

            //Project Exist ?
            var project = await _projectService.GetProjectById(id);
            if (project == null) return BadRequest("Project Not found");

            var projectUpdated = _mapperService.Map<SaveProjectRessource, Project>(saveProjectRessource);
            await _projectService.UpdateProject(project, projectUpdated);

            var projectUpdateNew = await _projectService.GetProjectById(id);
            var projectRessourceUpdate = _mapperService.Map<Project, ProjectRessource>(projectUpdateNew);
            return Ok(projectRessourceUpdate);

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProject(int id)
        {
            var projectToDelete = await _projectService.GetProjectById(id);
            if (projectToDelete == null) return BadRequest("Project not found");

            await _projectService.DeleteProject(projectToDelete);

            return NoContent();
        }

    }
}
