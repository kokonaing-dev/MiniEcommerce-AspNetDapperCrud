using Dapper;
using ECommerceApp.Data;
using ECommerceApp.Entities;

namespace ECommerceApp.Repositories;

public class CategoryRepository
{
    private readonly DapperContext _context;

    public CategoryRepository(DapperContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Category>> GetAllAsync()
    {
        var sql = "SELECT * FROM Categories";
        using var connection = _context.CreateConnection();
        return await connection.QueryAsync<Category>(sql);
    }

    public async Task<Category?> GetByIdAsync(int id)
    {
        var sql = "SELECT * FROM Categories WHERE Id = @Id";
        using var connection = _context.CreateConnection();
        return await connection.QueryFirstOrDefaultAsync<Category>(sql, new { Id = id });
    }

    public async Task<int> CreateAsync(Category category)
    {
        var sql = "INSERT INTO Categories (Name) VALUES (@Name)";
        using var connection = _context.CreateConnection();
        return await connection.ExecuteAsync(sql, category);
    }

    public async Task<int> UpdateAsync(Category category)
    {
        var sql = "UPDATE Categories SET Name = @Name WHERE Id = @Id";
        using var connection = _context.CreateConnection();
        return await connection.ExecuteAsync(sql, category);
    }

    public async Task<int> DeleteAsync(int id)
    {
        var sql = "DELETE FROM Categories WHERE Id = @Id";
        using var connection = _context.CreateConnection();
        return await connection.ExecuteAsync(sql, new { Id = id });
    }
}
