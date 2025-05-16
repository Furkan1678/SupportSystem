using Dapper;
using SupportRequestManagement.Domain.Entities; // Doğru namespace
using SupportRequestManagement.Domain.Enums;
using SupportRequestManagement.Domain.Interfaces;
using System.Data;

namespace SupportRequestManagement.Infrastructure.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly IDbConnection _dbConnection;

        public UserRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<SupportRequestManagement.Domain.Entities.User> GetByIdAsync(int id)
        {
            var sql = "SELECT * FROM users WHERE id = @Id";
            return await _dbConnection.QuerySingleOrDefaultAsync<SupportRequestManagement.Domain.Entities.User>(sql, new { Id = id });
        }

        public async Task<SupportRequestManagement.Domain.Entities.User> GetByUsernameAsync(string username)
        {
            var sql = "SELECT id, username, password_hash AS PasswordHash, email, role, created_at AS CreatedAt, last_login AS LastLogin " +
                      "FROM users WHERE username = @Username";
            var user = await _dbConnection.QuerySingleOrDefaultAsync<SupportRequestManagement.Domain.Entities.User>(sql, new { Username = username });
            Console.WriteLine($"GetByUsernameAsync: Username={username}, Bulundu={user != null}, " +
                             $"Id={user?.Id}, Hash={(user != null ? user.PasswordHash : "null")}, Email={user?.Email}");
            return user;
        }

        public async Task<SupportRequestManagement.Domain.Entities.User> GetByEmailAsync(string email)
        {
            var sql = "SELECT * FROM users WHERE email = @Email";
            return await _dbConnection.QuerySingleOrDefaultAsync<SupportRequestManagement.Domain.Entities.User>(sql, new { Email = email });
        }

        public async Task<List<SupportRequestManagement.Domain.Entities.User>> GetAllAsync()
        {
            var sql = "SELECT * FROM users";
            return (await _dbConnection.QueryAsync<SupportRequestManagement.Domain.Entities.User>(sql)).ToList();
        }

        public async Task<List<SupportRequestManagement.Domain.Entities.User>> GetByRoleAsync(UserRole role)
        {
            var sql = "SELECT * FROM users WHERE role = @Role";
            return (await _dbConnection.QueryAsync<SupportRequestManagement.Domain.Entities.User>(sql, new { Role = role })).ToList();
        }

        public async Task AddAsync(SupportRequestManagement.Domain.Entities.User user)
        {
            var sql = "INSERT INTO users (username, password_hash, email, role, created_at) " +
                      "VALUES (@Username, @PasswordHash, @Email, @Role, @CreatedAt)";
            await _dbConnection.ExecuteAsync(sql, user);
        }

        public async Task UpdateAsync(SupportRequestManagement.Domain.Entities.User user)
        {
            var sql = "UPDATE users SET username = @Username, password_hash = @PasswordHash, email = @Email, " +
                      "role = @Role, last_login = @LastLogin WHERE id = @Id";
            await _dbConnection.ExecuteAsync(sql, user);
        }

        public async Task DeleteAsync(int id)
        {
            var sql = "DELETE FROM users WHERE id = @Id";
            await _dbConnection.ExecuteAsync(sql, new { Id = id });
        }

        public async Task TestConnectionAsync()
        {
            var sql = "SELECT COUNT(*) FROM users";
            var count = await _dbConnection.ExecuteScalarAsync<int>(sql);
            Console.WriteLine($"Veritabanında {count} kullanıcı var.");
        }
    }
}