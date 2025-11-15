using ECommerceApp.DTOs;
using ECommerceApp.Entities;

namespace ECommerceApp.Repositories;

public interface IProductRepository
{
    Task<bool> CreateAsync(Product product);
    Task<bool> DeleteAsync(int id);
    Task<IEnumerable<ProductDto>> GetAllAsync();
    Task<ProductDto?> GetByIdAsync(int id);
    Task<bool> UpdateAsync(Product product);
}