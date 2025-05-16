using Dapper;
using SupportRequestManagement.Domain.Entities;
using SupportRequestManagement.Domain.Interfaces;
using SupportRequestManagement.Domain.Entities;
using SupportRequestManagement.Domain.Interfaces;
using System.Data;

namespace SupportRequestManagement.Infrastructure.Data
{
    public class SupportRequestCommentRepository : ISupportRequestCommentRepository
    {
        private readonly IDbConnection _dbConnection;

        public SupportRequestCommentRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<SupportRequestComment> GetByIdAsync(int id)
        {
            var sql = "SELECT * FROM SupportRequestComments WHERE Id = @Id";
            return await _dbConnection.QuerySingleOrDefaultAsync<SupportRequestComment>(sql, new { Id = id });
        }

        public async Task<List<SupportRequestComment>> GetBySupportRequestIdAsync(int supportRequestId)
        {
            var sql = "SELECT * FROM SupportRequestComments WHERE SupportRequestId = @SupportRequestId";
            return (await _dbConnection.QueryAsync<SupportRequestComment>(sql, new { SupportRequestId = supportRequestId })).ToList();
        }

        public async Task<List<SupportRequestComment>> GetAdminCommentsBySupportRequestIdAsync(int supportRequestId)
        {
            var sql = "SELECT * FROM SupportRequestComments WHERE SupportRequestId = @SupportRequestId AND IsAdminComment = 1";
            return (await _dbConnection.QueryAsync<SupportRequestComment>(sql, new { SupportRequestId = supportRequestId })).ToList();
        }

        public async Task AddAsync(SupportRequestComment comment)
        {
            var sql = "INSERT INTO SupportRequestComments (SupportRequestId, UserId, Comment, CreatedAt, IsAdminComment) " +
                      "VALUES (@SupportRequestId, @UserId, @Comment, @CreatedAt, @IsAdminComment)";
            await _dbConnection.ExecuteAsync(sql, comment);
        }

        public async Task UpdateAsync(SupportRequestComment comment)
        {
            var sql = "UPDATE SupportRequestComments SET SupportRequestId = @SupportRequestId, UserId = @UserId, " +
                      "Comment = @Comment, IsAdminComment = @IsAdminComment WHERE Id = @Id";
            await _dbConnection.ExecuteAsync(sql, comment);
        }

        public async Task DeleteAsync(int id)
        {
            var sql = "DELETE FROM SupportRequestComments WHERE Id = @Id";
            await _dbConnection.ExecuteAsync(sql, new { Id = id });
        }
    }
}