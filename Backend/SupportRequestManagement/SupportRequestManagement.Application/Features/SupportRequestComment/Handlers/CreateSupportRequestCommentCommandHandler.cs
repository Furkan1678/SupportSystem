using AutoMapper;
using MediatR;
using SupportRequestManagement.Application.Features.SupportRequestComment.Commands;

using SupportRequestManagement.Application.Features.SupportRequestComment.Dtos;
using SupportRequestManagement.Domain.Interfaces;

namespace SupportRequestManagement.Application.Features.SupportRequestComment.Handlers
{
    public class CreateSupportRequestCommentCommandHandler : IRequestHandler<CreateSupportRequestCommentCommand, SupportRequestCommentDto>
    {
        private readonly ISupportRequestCommentRepository _commentRepository;
        private readonly ISupportRequestRepository _supportRequestRepository;
        private readonly IMapper _mapper;

        public CreateSupportRequestCommentCommandHandler(
            ISupportRequestCommentRepository commentRepository,
            ISupportRequestRepository supportRequestRepository,
            IMapper mapper)
        {
            _commentRepository = commentRepository;
            _supportRequestRepository = supportRequestRepository;
            _mapper = mapper;
        }

        public async Task<SupportRequestCommentDto> Handle(CreateSupportRequestCommentCommand request, CancellationToken cancellationToken)
        {
            var supportRequest = await _supportRequestRepository.GetByIdAsync(request.SupportRequestId);
            if (supportRequest == null)
            {
                throw new Exception("Destek talebi bulunamadı");
            }

            var comment = _mapper.Map<SupportRequestManagement.Domain.Entities.SupportRequestComment>(request);
            comment.CreatedAt = DateTime.UtcNow;
            await _commentRepository.AddAsync(comment);

            return _mapper.Map<SupportRequestCommentDto>(comment);
        }
    }
}