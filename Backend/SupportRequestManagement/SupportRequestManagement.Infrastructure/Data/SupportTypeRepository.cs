using Dapper;
using SupportRequestManagement.Domain.Entities;
using SupportRequestManagement.Domain.Interfaces;
using SupportRequestManagement.Domain.Entities;
using SupportRequestManagement.Domain.Interfaces;
using System.Data;

namespace SupportRequestManagement.Infrastructure.Data
{
    public class SupportTypeRepository : ISupportTypeRepository
    {
        private readonly IDbConnection _dbConnection;

        public SupportTypeRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<SupportType> GetByIdAsync(int id)
        {
            var sql = "SELECT * FROM SupportTypes WHERE Id = @Id";
            return await _dbConnection.QuerySingleOrDefaultAsync<SupportType>(sql, new { Id = id });
        }

        public async Task<List<SupportType>> GetAllAsync()
        {
            var sql = "SELECT * FROM SupportTypes";
            return (await _dbConnection.QueryAsync<SupportType>(sql)).ToList();
        }

        public async Task<List<SupportType>> GetActiveAsync()
        {
            var sql = "SELECT * FROM SupportTypes WHERE IsActive = 1";
            return (await _dbConnection.QueryAsync<SupportType>(sql)).ToList();
        }

        public async Task AddAsync(SupportType type)
        {
            var sql = "INSERT INTO SupportTypes (Name, Description, CreatedAt, IsActive) VALUES (@Name, @Description, @CreatedAt, @IsActive)";
            await _dbConnection.ExecuteAsync(sql, type);
        }

        public async Task UpdateAsync(SupportType type)
        {
            var sql = "UPDATE SupportTypes SET Name = @Name, Description = @Description, IsActive = @IsActive WHERE Id = @Id";
            await _dbConnection.ExecuteAsync(sql, type);
        }

        public async Task DeleteAsync(int id)
        {
            var sql = "DELETE FROM SupportTypes WHERE Id = @Id";
            await _dbConnection.ExecuteAsync(sql, new { Id = id });
        }
    }
}
