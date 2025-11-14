using ECommerceApp.DTOs;

namespace ECommerceApp.Services
{
    public interface IProductService
    {
        Task<bool> CreateProductAsync(ProductDto dto);
        Task<bool> DeleteProductAsync(int id);
        Task<List<ProductDto>> GetAllProductsAsync();
        Task<ProductDto> ProdcutDetailAsync(int id);
        Task<bool> UpdateProductAsync(ProductDto dto);
    }
}