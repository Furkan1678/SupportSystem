using SupportRequestManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportRequestManagement.Domain.Interfaces
{
    public interface ISupportTypeRepository
    {
        Task<SupportType> GetByIdAsync(int id);
        Task<List<SupportType>> GetAllAsync();
        Task<List<SupportType>> GetActiveAsync();
        Task AddAsync(SupportType type);
        Task UpdateAsync(SupportType type);
        Task DeleteAsync(int id);
    }
}
