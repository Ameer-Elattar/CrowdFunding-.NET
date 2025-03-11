
using Crowd_Funding.Repositories.Generic;

namespace Crowd_Funding.Services
{
    public class TagService
    {
        private readonly IGenericRepository<Tag> tagRepository;

        public TagService(IGenericRepository<Tag> tagRepository)
        {
            this.tagRepository = tagRepository;
        }

        public async Task<IEnumerable<TagResponseDTO>> GetAllTagsAsync()
        {
            var tags = await tagRepository.GetAllAsync();
            return tags.Select(tag => new TagResponseDTO { Id = tag.Id, Name = tag.Name }).ToList();
        }
        public async Task<TagResponseDTO> GetTagByIdAsync(int id)
        {
            var tag = await tagRepository.GetByIdAsync(id);
            if (tag == null) return null;
            return new TagResponseDTO { Id = tag.Id, Name = tag.Name };
        }
        public async Task<TagResponseDTO> AddTagAsync(AddTagDTO requestTag)
        {
            Tag DBTag = new() { Name = requestTag.Name };
            await tagRepository.InsertAsync(DBTag);
            await tagRepository.SaveAsync();
            return new TagResponseDTO { Id = DBTag.Id, Name = DBTag.Name };
        }
        public async Task<bool> UpdateTagAsync(AddTagDTO requestTag, int id)
        {
            var DBTag = await tagRepository.GetByIdAsync(id);
            if (DBTag == null)
            {
                return false;
            }
            DBTag.Name = requestTag.Name;
            tagRepository.Update(DBTag);
            await tagRepository.SaveAsync();
            return true;
        }
        public async Task<bool> DeleteTagAsync(int id)
        {
            var DBTag = await tagRepository.GetByIdAsync(id);
            if (DBTag == null)
            {
                return false;
            }
            tagRepository.Delete(DBTag);
            await tagRepository.SaveAsync();
            return true;

        }
    }
}
