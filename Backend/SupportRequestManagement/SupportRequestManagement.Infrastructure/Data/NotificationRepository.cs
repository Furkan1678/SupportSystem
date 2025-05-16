using Dapper;
using SupportRequestManagement.Domain.Entities;
using SupportRequestManagement.Domain.Interfaces;
using System.Data;

namespace SupportRequestManagement.Infrastructure.Data
{
    public class NotificationRepository : INotificationRepository
    {
        private readonly IDbConnection _dbConnection;

        public NotificationRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<Notification> GetByIdAsync(int id)
        {
            var sql = "SELECT * FROM Notifications WHERE Id = @Id";
            return await _dbConnection.QuerySingleOrDefaultAsync<Notification>(sql, new { Id = id });
        }

        public async Task<List<Notification>> GetByUserIdAsync(int userId)
        {
            var sql = "SELECT * FROM Notifications WHERE UserId = @UserId";
            return (await _dbConnection.QueryAsync<Notification>(sql, new { UserId = userId })).ToList();
        }

        public async Task<List<Notification>> GetUnreadByUserIdAsync(int userId)
        {
            var sql = "SELECT * FROM Notifications WHERE UserId = @UserId AND IsRead = 0";
            return (await _dbConnection.QueryAsync<Notification>(sql, new { UserId = userId })).ToList();
        }

        public async Task<List<Notification>> GetBySupportRequestIdAsync(int supportRequestId)
        {
            var sql = "SELECT * FROM Notifications WHERE RelatedSupportRequestId = @SupportRequestId";
            return (await _dbConnection.QueryAsync<Notification>(sql, new { SupportRequestId = supportRequestId })).ToList();
        }

        public async Task AddAsync(Notification notification)
        {
            var sql = "INSERT INTO Notifications (UserId, Message, IsRead, CreatedAt, RelatedSupportRequestId) " +
                      "VALUES (@UserId, @Message, @IsRead, @CreatedAt, @RelatedSupportRequestId)";
            await _dbConnection.ExecuteAsync(sql, notification);
        }

        public async Task UpdateAsync(Notification notification)
        {
            var sql = "UPDATE Notifications SET UserId = @UserId, Message = @Message, IsRead = @IsRead, " +
                      "RelatedSupportRequestId = @RelatedSupportRequestId WHERE Id = @Id";
            await _dbConnection.ExecuteAsync(sql, notification);
        }

        public async Task DeleteAsync(int id)
        {
            var sql = "DELETE FROM Notifications WHERE Id = @Id";
            await _dbConnection.ExecuteAsync(sql, new { Id = id });
        }
    }
}