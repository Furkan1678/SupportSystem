using MediatR;
using SupportRequestManagement.Application.Features.SupportRequestComment.Dtos;

namespace SupportRequestManagement.Application.Features.SupportRequestComment.Queries
{
    public class GetCommentsBySupportRequestQuery : IRequest<List<SupportRequestCommentDto>>
    {
        public int SupportRequestId { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}