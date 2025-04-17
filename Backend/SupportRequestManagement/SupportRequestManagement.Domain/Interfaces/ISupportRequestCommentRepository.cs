using SupportRequestManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportRequestManagement.Domain.Interfaces
{
    public interface ISupportRequestCommentRepository
    {
        Task<SupportRequestComment> GetByIdAsync(int id);
        Task<List<SupportRequestComment>> GetBySupportRequestIdAsync(int supportRequestId);
        Task<List<SupportRequestComment>> GetAdminCommentsBySupportRequestIdAsync(int supportRequestId);
        Task AddAsync(SupportRequestComment comment);
        Task UpdateAsync(SupportRequestComment comment);
        Task DeleteAsync(int id);
    }
}
