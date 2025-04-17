using SupportRequestManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportRequestManagement.Domain.Interfaces
{
    public interface ISupportCategoryRepository
    {
        Task<SupportCategory> GetByIdAsync(int id);
        Task<List<SupportCategory>> GetAllAsync();
        Task<List<SupportCategory>> GetActiveAsync();
        Task AddAsync(SupportCategory category);
        Task UpdateAsync(SupportCategory category);
        Task DeleteAsync(int id);
    }
}
