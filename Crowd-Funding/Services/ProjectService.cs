
using Crowd_Funding.Repositories.Generic;

namespace Crowd_Funding.Services
{
    public class ProjectService
    {
        private readonly IProjectRepository projectRepository;
        private readonly IGenericRepository<Tag> tagRepository;
        private readonly FileService fileService;
        private readonly IProjectPicsRepository projectPicsRepository;
        private readonly IHttpContextAccessor httpContextAccessor;

        public ProjectService(IProjectRepository _projectRepository, IGenericRepository<Tag> TagRepository
            , FileService fileService, IProjectPicsRepository projectPicsRepository, IHttpContextAccessor httpContextAccessor)
        {
            this.projectRepository = _projectRepository;
            tagRepository = TagRepository;
            this.fileService = fileService;
            this.projectPicsRepository = projectPicsRepository;
            this.httpContextAccessor = httpContextAccessor;
        }
        public IEnumerable<ProjectWithIncludeDTO> GetAllProjects()
        {
            return projectRepository.GetProjectWithInclude();
        }
        public async Task<Project> AddProject(AddProjectDTO requestProject)
        {
            var tags = await tagRepository.GetAllAsync();
            var selectedTags = tags.Where(tag => requestProject.TagIDs.Contains(tag.Id)).ToList();
            var project = new Project()
            {
                Name = requestProject.Name,
                Description = requestProject.Description,
                StartDate = requestProject.StartDate,
                EndDate = requestProject.EndDate,
                TargetMoney = requestProject.TargetMoney,
                Status = requestProject.Status,
                CategoryID = requestProject.CategoryID,
                UserID = requestProject.UserID,
                Tags = selectedTags,
                ImagePaths = new List<ProjectPics>()
            };
            await projectRepository.InsertAsync(project);
            await projectRepository.SaveAsync();
            if (requestProject.Files != null && requestProject.Files.Count > 0)
            {
                var paths = await fileService.UploadFiles(requestProject.Files);
                var imagePaths = new List<ProjectPics>();

                for (int i = 0; i < paths.Count; i++)
                {
                    imagePaths.Add(new ProjectPics
                    {
                        PicPath = paths[i],
                        ProjectId = project.Id,
                        IsMain = (i == 0)
                    });
                }
                await projectPicsRepository.InsertRangeAsync(imagePaths);
                await projectPicsRepository.SaveAsync();
            }
            return new Project
            {
                Id = project.Id,
                Name = project.Name,
                Description = project.Description,
                StartDate = project.StartDate,
                EndDate = project.EndDate,
                TargetMoney = project.TargetMoney,
                Status = project.Status,
            };
        }
        public ProjectResponseDTO GetProjectFullDataAsync(int id)
        {
            var project = projectRepository.GetProjectFullData(id);
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
                Category = project.Category != null ? new CategoryResponseDTO()
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

            if (requestProject.Files != null && requestProject.Files.Count > 0)
            {
                var oldImages = projectPicsRepository.GetProjectPics(project.Id).ToList();
                var oldImagePaths = oldImages.Select(pp => pp.PicPath).ToList();

                if (oldImagePaths.Any())
                {
                    fileService.DeleteFiles(oldImagePaths);
                }

                foreach (var oldImage in oldImages)
                {
                    projectPicsRepository.Delete(oldImage);
                }

                var newPaths = await fileService.UploadFiles(requestProject.Files);
                var newImagePaths = new List<ProjectPics>();

                for (int i = 0; i < newPaths.Count; i++)
                {
                    newImagePaths.Add(new ProjectPics
                    {
                        PicPath = newPaths[i],
                        ProjectId = project.Id,
                        IsMain = (i == 0)
                    });
                }

                project.ImagePaths.Clear();
                project.ImagePaths.AddRange(newImagePaths);
            }

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
            var ImagesPaths = projectPicsRepository.GetProjectPics(project.Id).Select(pp => pp.PicPath).ToList();
            projectRepository.Delete(project);
            await projectRepository.SaveAsync();
            fileService.DeleteFiles(ImagesPaths);
            return true;
        }
    }
}
