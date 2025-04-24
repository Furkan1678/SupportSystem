using MediatR;
using SupportRequestManagement.Application.Features.SupportCategory.Commands;
using SupportRequestManagement.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportRequestManagement.Application.Features.SupportCategory.Handlers
{
    public class DeleteSupportCategoryCommandHandler : IRequestHandler<DeleteSupportCategoryCommand>
    {
        private readonly ISupportCategoryRepository _supportCategoryRepository;

        public DeleteSupportCategoryCommandHandler(ISupportCategoryRepository supportCategoryRepository)
        {
            _supportCategoryRepository = supportCategoryRepository;
        }

        public async Task Handle(DeleteSupportCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _supportCategoryRepository.GetByIdAsync(request.Id);
            if (category == null)
            {
                throw new Exception("Destek kategorisi bulunamadı");
            }

            await _supportCategoryRepository.DeleteAsync(request.Id);
        }
    }
}
