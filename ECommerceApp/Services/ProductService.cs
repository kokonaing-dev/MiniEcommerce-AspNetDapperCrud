using ECommerceApp.DTOs;
using ECommerceApp.Entities;
using ECommerceApp.Repositories;

namespace ECommerceApp.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<List<ProductDto>> GetAllProductsAsync()
    {
        var products =  await _productRepository.GetAllAsync();
        return products.ToList();
    }

    public async Task<bool> CreateProductAsync(ProductDto dto)
    {
        var entity = new Product
        {
            Name = dto.Name,
            Description = dto.Description,
            Price = dto.Price,
            ImageUrl = dto.ImageUrl,
            CategoryId = dto.CategoryId
        };

        int result = await _productRepository.CreateAsync(entity);
        if (result > 0) return true;

        return false;

    }

    public async Task<bool> UpdateProductAsync(ProductDto dto)
    {
        var entity = new Product
        {
            Id = dto.Id,
            Name = dto.Name,
            Description = dto.Description,
            Price = dto.Price,
            ImageUrl = dto.ImageUrl,
            CategoryId = dto.CategoryId
        };

        return await _productRepository.UpdateAsync(entity);
    }

    public async Task<ProductDto> ProdcutDetailAsync(int id)
    {
        var product = await _productRepository.GetByIdAsync(id);

        return product ?? new ProductDto();
    }

    public async Task<bool> DeleteProductAsync(int id)
    {
        return await _productRepository.DeleteAsync(id);
    }
}
