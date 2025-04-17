using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportRequestManagement.Domain.Entities
{
    public class SupportRequestComment
    {
        public int Id { get; set; }
        public int SupportRequestId { get; set; }
        public int UserId { get; set; }
        public string Comment { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsAdminComment { get; set; }
    }
}
