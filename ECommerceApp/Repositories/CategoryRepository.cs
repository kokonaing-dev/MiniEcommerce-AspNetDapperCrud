using Dapper;
using ECommerceApp.Data;
using ECommerceApp.DTOs;
using ECommerceApp.Entities;

namespace ECommerceApp.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly DapperContext _context;

    public CategoryRepository(DapperContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<CategoryDto>> GetAllAsync()
    {
        var sql = "SELECT * FROM Category WHERE IsDeleted = 0";
        using var connection = _context.CreateConnection();
        return await connection.QueryAsync<CategoryDto>(sql);
    }

    public async Task<CategoryDto?> GetByIdAsync(int id)
    {
        var sql = "SELECT * FROM Category WHERE Id = @Id";
        using var connection = _context.CreateConnection();
        return await connection.QueryFirstOrDefaultAsync<CategoryDto>(sql, new { Id = id });
    }

    public async Task<bool> CreateAsync(Category category)
    {
        category.IsDeleted = false;
        category.CreatedDate = DateTime.UtcNow;

        var sql = "INSERT INTO Category (Name,IsDeleted,CreatedDate) VALUES (@Name,@IsDeleted,@CreatedDate)";
        using var connection = _context.CreateConnection();
        var rows = await connection.ExecuteAsync(sql, category);
        return rows > 0;
    }

    public async Task<bool> UpdateAsync(Category category)
    {
        category.UpdatedDate = DateTime.UtcNow;

        var sql = "UPDATE Category SET Name = @Name, UpdatedDate = @UpdatedDate WHERE Id = @Id";
        using var connection = _context.CreateConnection();
        var rows = await connection.ExecuteAsync(sql, category);
        return rows > 0;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var sql = "UPDATE Category SET IsDeleted = 1 WHERE Id = @Id";
        using var connection = _context.CreateConnection();
        var rows = await connection.ExecuteAsync(sql, new { Id = id });
        return rows > 0;
    }
}
