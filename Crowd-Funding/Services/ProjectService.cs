using Crowd_Funding.DTO.Category;
using Crowd_Funding.DTO.Project;

namespace Crowd_Funding.Services
{
    public class ProjectService
    {
        private readonly IProjectRepository projectRepository;

        public ProjectService(IProjectRepository _projectRepository)
        {
            this.projectRepository = _projectRepository;

        }
        public IEnumerable<ProjectWithIncludeDTO> GetAllProjects()
        {
            return projectRepository.GetProjectWithInclude();
        }
        public async Task<Project> AddProject(AddProjectDTO requestProject)
        {
            var project = new Project()
            {
                Name = requestProject.Name,
                Description = requestProject.Description,
                StartDate = requestProject.StartDate,
                EndDate = requestProject.EndDate,
                TargetMoney = requestProject.TargetMoney,
                Status = requestProject.Status,
                CategoryID = requestProject.CategoryID,
                UserID = requestProject.UserID

            };
            await projectRepository.InsertAsync(project);
            await projectRepository.SaveAsync();
            return project;
        }

        public async Task<ProjectWithIncludeDTO> GetProjectByID(int id)
        {
            var project = await projectRepository.GetByIdAsync(id);
            if (project == null) return null;

            var projectDTO = new ProjectWithIncludeDTO()
            {
                Id = project.Id,
                Name = project.Name,
                Description = project.Description,
                StartDate = project.StartDate,
                EndDate = project.EndDate,
                TargetMoney = project.TargetMoney,
                Status = project.Status,
                Category = project.Category != null ? new GetCategoryDTO()
                {
                    Id = project.Category.Id,
                    Name = project.Category.Name,
                    Description = project.Category.Description
                } : null
            };
            return projectDTO;
        }



        public async Task<bool> UpdateProject(UpdateProjectDTO requestProject)
        {
            var project = await projectRepository.GetByIdAsync(requestProject.Id);
            if (project == null)
            {
                return false;
            }
            project.Name = requestProject.Name ?? project.Name;
            project.Description = requestProject.Description ?? project.Description;
            project.TargetMoney = requestProject.TargetMoney ?? project.TargetMoney;
            project.StartDate = requestProject.StartDate ?? project.StartDate;
            project.EndDate = requestProject.EndDate ?? project.EndDate;
            project.CategoryID = requestProject.CategoryID ?? project.CategoryID;
            project.UserID = requestProject.UserID ?? project.UserID;

            projectRepository.Update(project);
            await projectRepository.SaveAsync();
            return true;
        }

        public async Task<bool> DeleteProject(int id)
        {
            var project = await projectRepository.GetByIdAsync(id);
            if (project == null)
            {
                return false;
            }
            projectRepository.Delete(project);
            await projectRepository.SaveAsync();
            return true;
        }
    }
}
