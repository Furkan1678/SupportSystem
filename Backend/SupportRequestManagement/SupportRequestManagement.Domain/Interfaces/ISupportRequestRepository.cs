using SupportRequestManagement.Domain.Entities;
using SupportRequestManagement.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportRequestManagement.Domain.Interfaces
{
    public interface ISupportRequestRepository
    {
        Task<SupportRequest> GetByIdAsync(int id);
        Task<List<SupportRequest>> GetAllAsync();
        Task<List<SupportRequest>> GetByUserIdAsync(int userId);
        Task<List<SupportRequest>> GetByStatusAsync(SupportRequestStatus status);
        Task<List<SupportRequest>> GetByAssignedAdminIdAsync(int? adminId);
        Task AddAsync(SupportRequest supportRequest);
        Task UpdateAsync(SupportRequest supportRequest);
        Task DeleteAsync(int id);
    }
}
