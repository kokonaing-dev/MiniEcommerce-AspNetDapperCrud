using ECommerceApp.DTOs;
using ECommerceApp.Entities;
using ECommerceApp.Repositories;

namespace ECommerceApp.Services;

public class CategoryService
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryService(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<List<CategoryDto>> GetCategoriesAsync()
    {
        var categories = await _categoryRepository.GetAllAsync();

        return categories.ToList();
    }

    public async Task<bool> CreateCategoryAsync(CategoryDto dto)
    {
        var category = new Category
        {
            Name = dto.Name,
        };

        return await _categoryRepository.CreateAsync(category);
        
    }

    public async Task<bool> UpdateCategoryAsync(CategoryDto dto)
    {
        var category = new Category
        {
            Name = dto.Name,
        };

        return await _categoryRepository.UpdateAsync(category);
       
    }

    public async Task<CategoryDto?> CategoryDetailAsync(int id)
    {
        return await _categoryRepository.GetByIdAsync(id);
    }

    public async Task<bool> DeleteCategoryAsync(int id)
    {
        return await _categoryRepository.DeleteAsync(id);

    }
}
