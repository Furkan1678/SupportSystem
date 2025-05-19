using Dapper;
using SupportRequestManagement.Domain.Entities; 
using SupportRequestManagement.Domain.Enums;
using SupportRequestManagement.Domain.Interfaces;
using System.Data;

namespace SupportRequestManagement.Infrastructure.Data
{
    public class SupportRequestRepository : ISupportRequestRepository
    {
        private readonly IDbConnection _dbConnection;

        public SupportRequestRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<SupportRequestManagement.Domain.Entities.SupportRequest> GetByIdAsync(int id)
        {
            var sql = "SELECT id AS Id, user_id AS UserId, support_type_id AS SupportTypeId, support_category_id AS SupportCategoryId, " +
                      "subject AS Subject, description AS Description, attachment_url AS AttachmentUrl, status AS Status, " +
                      "assigned_admin_id AS AssignedAdminId, created_at AS CreatedAt, updated_at AS UpdatedAt, priority AS Priority " +
                      "FROM support_requests WHERE id = @Id";
            var supportRequest = await _dbConnection.QuerySingleOrDefaultAsync<SupportRequestManagement.Domain.Entities.SupportRequest>(sql, new { Id = id });
            if (supportRequest != null && supportRequest.UserId <= 0)
            {
                throw new Exception($"GetByIdAsync: id={id} için user_id geçersiz ({supportRequest.UserId}). Veritabanında user_id değerini kontrol edin.");
            }
            return supportRequest;
        }

        public async Task<List<SupportRequestManagement.Domain.Entities.SupportRequest>> GetAllAsync()
        {
            var sql = "SELECT id AS Id, user_id AS UserId, support_type_id AS SupportTypeId, support_category_id AS SupportCategoryId, " +
                      "subject AS Subject, description AS Description, attachment_url AS AttachmentUrl, status AS Status, " +
                      "assigned_admin_id AS AssignedAdminId, created_at AS CreatedAt, updated_at AS UpdatedAt, priority AS Priority " +
                      "FROM support_requests";
            return (await _dbConnection.QueryAsync<SupportRequestManagement.Domain.Entities.SupportRequest>(sql)).ToList();
        }

        public async Task<List<SupportRequestManagement.Domain.Entities.SupportRequest>> GetByUserIdAsync(int userId)
        {
            var sql = "SELECT id AS Id, user_id AS UserId, support_type_id AS SupportTypeId, support_category_id AS SupportCategoryId, " +
                      "subject AS Subject, description AS Description, attachment_url AS AttachmentUrl, status AS Status, " +
                      "assigned_admin_id AS AssignedAdminId, created_at AS CreatedAt, updated_at AS UpdatedAt, priority AS Priority " +
                      "FROM support_requests WHERE user_id = @UserId";
            return (await _dbConnection.QueryAsync<SupportRequestManagement.Domain.Entities.SupportRequest>(sql, new { UserId = userId })).ToList();
        }

        public async Task<List<SupportRequestManagement.Domain.Entities.SupportRequest>> GetByStatusAsync(SupportRequestStatus status)
        {
            var sql = "SELECT id AS Id, user_id AS UserId, support_type_id AS SupportTypeId, support_category_id AS SupportCategoryId, " +
                      "subject AS Subject, description AS Description, attachment_url AS AttachmentUrl, status AS Status, " +
                      "assigned_admin_id AS AssignedAdminId, created_at AS CreatedAt, updated_at AS UpdatedAt, priority AS Priority " +
                      "FROM support_requests WHERE status = @Status";
            return (await _dbConnection.QueryAsync<SupportRequestManagement.Domain.Entities.SupportRequest>(sql, new { Status = status })).ToList();
        }

        public async Task<List<SupportRequestManagement.Domain.Entities.SupportRequest>> GetByAssignedAdminIdAsync(int? adminId)
        {
            var sql = "SELECT id AS Id, user_id AS UserId, support_type_id AS SupportTypeId, support_category_id AS SupportCategoryId, " +
                      "subject AS Subject, description AS Description, attachment_url AS AttachmentUrl, status AS Status, " +
                      "assigned_admin_id AS AssignedAdminId, created_at AS CreatedAt, updated_at AS UpdatedAt, priority AS Priority " +
                      "FROM support_requests WHERE assigned_admin_id = @AdminId";
            return (await _dbConnection.QueryAsync<SupportRequestManagement.Domain.Entities.SupportRequest>(sql, new { AdminId = adminId })).ToList();
        }

        public async Task AddAsync(SupportRequestManagement.Domain.Entities.SupportRequest supportRequest)
        {
            var sql = "INSERT INTO support_requests (user_id, support_type_id, support_category_id, subject, description, attachment_url, status, assigned_admin_id, created_at, priority) " +
                      "VALUES (@UserId, @SupportTypeId, @SupportCategoryId, @Subject, @Description, @AttachmentUrl, @Status, @AssignedAdminId, @CreatedAt, @Priority) " +
                      "RETURNING id";
            var id = await _dbConnection.ExecuteScalarAsync<int>(sql, supportRequest);
            supportRequest.Id = id;
        }

        public async Task UpdateAsync(SupportRequestManagement.Domain.Entities.SupportRequest supportRequest)
        {
            var sql = "UPDATE support_requests SET user_id = @UserId, support_type_id = @SupportTypeId, support_category_id = @SupportCategoryId, " +
                      "subject = @Subject, description = @Description, attachment_url = @AttachmentUrl, status = @Status, assigned_admin_id = @AssignedAdminId, " +
                      "updated_at = @UpdatedAt, priority = @Priority WHERE id = @Id";
            await _dbConnection.ExecuteAsync(sql, supportRequest);
        }

        public async Task DeleteAsync(int id)
        {
            var sql = "DELETE FROM support_requests WHERE id = @Id";
            await _dbConnection.ExecuteAsync(sql, new { Id = id });
        }
    }
}