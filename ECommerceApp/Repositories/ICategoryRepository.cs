using ECommerceApp.DTOs;
using ECommerceApp.Entities;

namespace ECommerceApp.Repositories
{
    public interface ICategoryRepository
    {
        Task<bool> CreateAsync(Category category);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<CategoryDto>> GetAllAsync();
        Task<CategoryDto?> GetByIdAsync(int id);
        Task<bool> UpdateAsync(Category category);
    }
}