using MediatR;
using SupportRequestManagement.Application.Features.SupportRequestComment.Dtos;
namespace SupportRequestManagement.Application.Features.SupportRequestComment.Commands
{
    public class CreateSupportRequestCommentCommand : IRequest<SupportRequestCommentDto>
    {
        public int SupportRequestId { get; set; }
        public int UserId { get; set; }
        public string Comment { get; set; }
        public bool IsAdminComment { get; set; }
    }
}
