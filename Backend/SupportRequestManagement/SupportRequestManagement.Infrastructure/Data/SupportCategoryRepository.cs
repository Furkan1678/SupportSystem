using Dapper;
using SupportRequestManagement.Domain.Entities;
using SupportRequestManagement.Domain.Interfaces;
using System.Data;

namespace SupportRequestManagement.Infrastructure.Data
{
    public class SupportCategoryRepository : ISupportCategoryRepository
    {
        private readonly IDbConnection _dbConnection;

        public SupportCategoryRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<SupportCategory> GetByIdAsync(int id)
        {
            var sql = "SELECT * FROM SupportCategories WHERE Id = @Id";
            return await _dbConnection.QuerySingleOrDefaultAsync<SupportCategory>(sql, new { Id = id });
        }

        public async Task<List<SupportCategory>> GetAllAsync()
        {
            var sql = "SELECT * FROM SupportCategories";
            return (await _dbConnection.QueryAsync<SupportCategory>(sql)).ToList();
        }

        public async Task<List<SupportCategory>> GetActiveAsync()
        {
            var sql = "SELECT * FROM SupportCategories WHERE IsActive = 1";
            return (await _dbConnection.QueryAsync<SupportCategory>(sql)).ToList();
        }

        public async Task AddAsync(SupportCategory category)
        {
            var sql = "INSERT INTO SupportCategories (Name, Description, CreatedAt, IsActive) VALUES (@Name, @Description, @CreatedAt, @IsActive)";
            await _dbConnection.ExecuteAsync(sql, category);
        }

        public async Task UpdateAsync(SupportCategory category)
        {
            var sql = "UPDATE SupportCategories SET Name = @Name, Description = @Description, IsActive = @IsActive WHERE Id = @Id";
            await _dbConnection.ExecuteAsync(sql, category);
        }

        public async Task DeleteAsync(int id)
        {
            var sql = "DELETE FROM SupportCategories WHERE Id = @Id";
            await _dbConnection.ExecuteAsync(sql, new { Id = id });
        }
    }
}
