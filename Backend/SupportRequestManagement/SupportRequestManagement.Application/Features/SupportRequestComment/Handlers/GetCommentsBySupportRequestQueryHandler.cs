using AutoMapper;
using MediatR;
using SupportRequestManagement.Application.Features.SupportRequestComment.Dtos;

using SupportRequestManagement.Application.Features.SupportRequestComment.Queries;

using SupportRequestManagement.Domain.Interfaces;
namespace SupportRequestManagement.Application.Features.SupportRequestComment.Handlers
{
    public class GetCommentsBySupportRequestQueryHandler : IRequestHandler<GetCommentsBySupportRequestQuery, List<SupportRequestCommentDto>>
    {
        private readonly ISupportRequestCommentRepository _commentRepository;
        private readonly IMapper _mapper;

        public GetCommentsBySupportRequestQueryHandler(ISupportRequestCommentRepository commentRepository, IMapper mapper)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
        }

        public async Task<List<SupportRequestCommentDto>> Handle(GetCommentsBySupportRequestQuery request, CancellationToken cancellationToken)
        {
            var comments = await _commentRepository.GetBySupportRequestIdAsync(request.SupportRequestId);
            return _mapper.Map<List<SupportRequestCommentDto>>(
                comments.Skip((request.PageNumber - 1) * request.PageSize).Take(request.PageSize).ToList());
        }
    }
}