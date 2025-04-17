﻿using SupportRequestManagement.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportRequestManagement.Domain.Entities
{
    public class SupportRequest
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int SupportTypeId { get; set; }
        public int SupportCategoryId { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public string? AttachmentUrl { get; set; }
        public SupportRequestStatus Status { get; set; }
        public int? AssignedAdminId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int Priority { get; set; }
    }
}
