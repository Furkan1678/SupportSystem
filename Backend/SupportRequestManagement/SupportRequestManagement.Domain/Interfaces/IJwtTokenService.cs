using SupportRequestManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportRequestManagement.Domain.Interfaces
{
    public interface IJwtTokenService
    {
        string GenerateToken(User user); //GenerateToken yerine başka isim kullanılabilir şimdilik böyle ayarlayalım.
    }
}
