using Crowd_Funding.DTO;
using Crowd_Funding.Models;
using Crowd_Funding.Repositories.Generic;

namespace Crowd_Funding.Services
{
    public class CategoryService
    {
        private readonly IGenericRepository<Category> CategoryRepo;

        public CategoryService(IGenericRepository<Category> _categoryRepo)
        {
            CategoryRepo = _categoryRepo;
        }
        public async Task<IEnumerable<CategoryResponseDTO>> GetAllCategoriesAsync()
        {
            var categories = await CategoryRepo.GetAllAsync();

            var categoriesDTO = new List<CategoryResponseDTO>();
            foreach (var item in categories)
            {
                categoriesDTO.Add(new CategoryResponseDTO
                {
                    Id = item.Id,
                    Name = item.Name,
                    Description = item.Description
                });
            }
            return categoriesDTO;
        }

        public async Task<CategoryResponseDTO> GetCategoryByIdAsync(int id)
        {
            var category = await CategoryRepo.GetByIdAsync(id);
            if (category == null) return null;

            return new CategoryResponseDTO()
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description
            };
        }
        public async Task<Category> AddCategoryAsync(AddCategoryDTO categoryFromRequest)
        {
            var category = new Category()
            {
                Name = categoryFromRequest.Name,
                Description = categoryFromRequest.Description
            };
            await CategoryRepo.InsertAsync(category);
            await CategoryRepo.SaveAsync();
            return category;
        }
        public async Task UpdateCategoryAsync(CategoryResponseDTO categoryFromRequest)
        {
            var category = new Category()
            {
                Id = categoryFromRequest.Id,
                Name = categoryFromRequest.Name,
                Description = categoryFromRequest.Description
            };
            CategoryRepo.Update(category);
            await CategoryRepo.SaveAsync();
        }
        public async Task<bool> DeleteCategoryAsync(int id)
        {
            var category = await CategoryRepo.GetByIdAsync(id);
            if (category == null)
            {
                return false;
            }
            CategoryRepo.Delete(category);
            await CategoryRepo.SaveAsync();
            return true;
        }
    }
}
