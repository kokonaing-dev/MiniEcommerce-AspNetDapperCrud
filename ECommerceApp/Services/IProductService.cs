using ECommerceApp.DTOs;

namespace ECommerceApp.Services;

public interface IProductService
{
    Task<bool> CreateProductAsync(CreateProductDto dto);
    Task<bool> UpdateProductAsync(int id, UpdateProductDto dto);
    Task<bool> DeleteProductAsync(int id);
    Task<List<ProductDto>> GetAllProductsAsync();
    Task<ProductDto?> ProductDetailAsync(int id);
}
