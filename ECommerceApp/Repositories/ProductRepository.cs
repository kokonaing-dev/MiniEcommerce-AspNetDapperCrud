using Dapper;
using ECommerceApp.Data;
using ECommerceApp.DTOs;
using ECommerceApp.Entities;

namespace ECommerceApp.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly DapperContext _context;

    public ProductRepository(DapperContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<ProductDto>> GetAllAsync()
    {
        var sql = @"
        SELECT p.Id, p.Name, p.Description, p.Price, 
               p.CategoryId, c.Name AS CategoryName, 
               p.CreatedDate AS Created
        FROM Product p
        INNER JOIN Category c ON p.CategoryId = c.Id
        WHERE p.IsDeleted = 0";

        using var connection = _context.CreateConnection();
        return await connection.QueryAsync<ProductDto>(sql);
    }

    public async Task<ProductDto?> GetByIdAsync(int id)
    {
        var sql = @"
        SELECT p.Id, p.Name, p.Description, p.Price,
               p.CategoryId, c.Name AS CategoryName, 
               p.CreatedDate AS Created,
               p.UpdatedDate AS Updated
        FROM Product p
        INNER JOIN Category c ON p.CategoryId = c.Id
        WHERE p.Id = @Id AND p.IsDeleted = 0";

        using var connection = _context.CreateConnection();
        return await connection.QueryFirstOrDefaultAsync<ProductDto>(sql, new { Id = id });
    }

    public async Task<bool> CreateAsync(Product product)
    {
        product.CreatedDate = DateTime.UtcNow;
        product.IsDeleted = false;

        var sql = @"
        INSERT INTO Product (Name, Description, Price, CategoryId, CreatedDate, IsDeleted)
        VALUES (@Name, @Description, @Price, @CategoryId, @CreatedDate, @IsDeleted);
    ";

        using var connection = _context.CreateConnection();
        var rows = await connection.ExecuteAsync(sql, product);

        return rows > 0; 
    }

    public async Task<bool> UpdateAsync(Product product)
    {
        product.UpdatedDate = DateTime.UtcNow;

        var sql = @"
        UPDATE Product
        SET Name = @Name,
            Description = @Description,
            Price = @Price,
            CategoryId = @CategoryId,
            UpdatedDate = @UpdatedDate
        WHERE Id = @Id AND IsDeleted = 0";

        using var connection = _context.CreateConnection();
        var rows = await connection.ExecuteAsync(sql, product);
        return rows > 0;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var sql = @"UPDATE Product SET IsDeleted = 1  WHERE Id = @Id";

        using var connection = _context.CreateConnection();
        var rows = await connection.ExecuteAsync(sql, new { Id = id });
        return rows > 0;
    }
}
