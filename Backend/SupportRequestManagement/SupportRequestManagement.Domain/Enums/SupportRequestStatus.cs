using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportRequestManagement.Domain.Enums
{
    public enum SupportRequestStatus
    {
        Beklemede = 0,
        DevamEdiyor = 1,
        Tamamlandi = 2,
        Reddedildi = 3,
        Bekletiliyor = 4
    }
}
