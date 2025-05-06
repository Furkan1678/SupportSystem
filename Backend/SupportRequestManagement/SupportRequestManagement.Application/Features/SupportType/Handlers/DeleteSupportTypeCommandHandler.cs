using MediatR;
using SupportRequestManagement.Application.Features.SupportType.Commands;
using SupportRequestManagement.Domain.Interfaces;

namespace SupportRequestManagement.Application.Features.SupportType.Handlers
{
    public class DeleteSupportTypeCommandHandler : IRequestHandler<DeleteSupportTypeCommand>
    {
        private readonly ISupportTypeRepository _supportTypeRepository;

        public DeleteSupportTypeCommandHandler(ISupportTypeRepository supportTypeRepository)
        {
            _supportTypeRepository = supportTypeRepository;
        }

        public async Task Handle(DeleteSupportTypeCommand request, CancellationToken cancellationToken)
        {
            var supportType = await _supportTypeRepository.GetByIdAsync(request.Id);
            if (supportType == null)
            {
                throw new Exception("Destek türü bulunamadı");
            }

            await _supportTypeRepository.DeleteAsync(request.Id);
        }
    }
}