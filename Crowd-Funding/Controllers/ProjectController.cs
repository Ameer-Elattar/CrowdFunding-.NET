using Crowd_Funding.Services;
using Microsoft.AspNetCore.Mvc;

namespace Crowd_Funding.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly ProjectService projectService;

        public ProjectController(ProjectService _projectService)
        {
            projectService = _projectService;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(projectService.GetAllProjects());
        }
        [HttpGet("full/{id:int}")]
        public IActionResult GetProjectfullData(int id)
        {
            var project = projectService.GetProjectFullDataAsync(id);
            if (project == null) return NotFound(new { message = "Project Not Found" });
            return Ok(project);
        }
        [HttpGet("{id:int}")]

        public async Task<IActionResult> GetByID(int id)
        {
            var project = await projectService.GetProjectByID(id);
            if (project == null) return NotFound(new { message = "Project Not Found" });
            return Ok(project);
        }
        [HttpPost]
        public async Task<IActionResult> AddProject(AddProjectDTO project)
        {
            var projectAdded = await projectService.AddProject(project);
            return Created();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateProject(UpdateProjectDTO project)
        {
            bool isUpdeted = await projectService.UpdateProject(project);
            if (!isUpdeted)
            {
                return NotFound(new { message = "Project Not Found" });
            }
            return Ok(new { message = "Project Updated" });
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteProject(int id)
        {
            bool isDeleted = await projectService.DeleteProject(id);
            if (!isDeleted)
            {
                return NotFound(new { message = "Project Not Found" });
            }
            return Ok(new { message = "Project Deleted" });
        }
    }
}
