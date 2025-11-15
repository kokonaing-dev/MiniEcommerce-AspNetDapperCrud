using ECommerceApp.DTOs;

namespace ECommerceApp.Services
{
    public interface ICategoryService
    {
        Task<CategoryDto?> CategoryDetailAsync(int id);
        Task<bool> CreateCategoryAsync(CategoryDto dto);
        Task<bool> DeleteCategoryAsync(int id);
        Task<List<CategoryDto>> GetCategoriesAsync();
        Task<bool> UpdateCategoryAsync(CategoryDto dto);
    }
}