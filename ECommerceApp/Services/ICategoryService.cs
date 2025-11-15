using ECommerceApp.DTOs;

namespace ECommerceApp.Services;

public interface ICategoryService
{
    Task<CategoryDto?> CategoryDetailAsync(int id);
    Task<bool> CreateCategoryAsync(CreateCategoryDto dto);
    Task<bool> DeleteCategoryAsync(int id);
    Task<List<CategoryDto>> GetCategoriesAsync();
    Task<bool> UpdateCategoryAsync(int id,UpdateCategoryDto dto);
}