using ECommerceApp.DTOs;
using ECommerceApp.Entities;
using ECommerceApp.Repositories;

namespace ECommerceApp.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _repo;

    public ProductService(IProductRepository repo)
    {
        _repo = repo;
    }

    public async Task<List<ProductDto>> GetAllProductsAsync()
    {
        var data = await _repo.GetAllAsync();
        return data.ToList();
    }


    public Task<ProductDto?> ProductDetailAsync(int id)
        => _repo.GetByIdAsync(id);

    public Task<bool> CreateProductAsync(CreateProductDto dto)
    {
        var entity = new Product
        {
            Name = dto.Name,
            Description = dto.Description,
            Price = dto.Price,
            CategoryId = dto.CategoryId,
            CreatedDate = DateTime.UtcNow
        };

        return _repo.CreateAsync(entity);
    }

    public Task<bool> UpdateProductAsync(int id, UpdateProductDto dto)
    {
        var entity = new Product
        {
            Id = id,
            Name = dto.Name,
            Description = dto.Description,
            Price = dto.Price,
            CategoryId = dto.CategoryId,
            UpdatedDate = DateTime.UtcNow
        };

        return _repo.UpdateAsync(entity);
    }

    public Task<bool> DeleteProductAsync(int id)
        => _repo.DeleteAsync(id);
}

