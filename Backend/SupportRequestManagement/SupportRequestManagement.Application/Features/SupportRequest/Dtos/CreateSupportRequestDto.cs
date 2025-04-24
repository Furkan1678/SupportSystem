using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportRequestManagement.Application.Features.SupportRequest.Dtos
{
    public class CreateSupportRequestDto
    {
        public int UserId { get; set; }
        public int SupportTypeId { get; set; }
        public int SupportCategoryId { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public string AttachmentUrl { get; set; }
        public int Priority { get; set; }
    }
}
