using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SupportRequestManagement.Application.Features.SupportRequest.Commands;
using SupportRequestManagement.Application.Features.SupportRequest.Queries;
using SupportRequestManagement.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportRequestManagement.Infrastructure.Services
{
    public class SupportRequestStatusUpdateService : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;

        public SupportRequestStatusUpdateService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using (var scope = _serviceProvider.CreateScope())
                {
                    var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();
                    var supportRequests = await mediator.Send(new GetAllSupportRequestsQuery());

                    foreach (var request in supportRequests)
                    {
                        if (request.Status == SupportRequestStatus.Beklemede &&
                            (DateTime.UtcNow - request.CreatedAt).TotalDays > 7)
                        {
                            await mediator.Send(new UpdateSupportRequestStatusCommand
                            {
                                Id = request.Id,
                                NewStatus = SupportRequestStatus.Bekletiliyor
                            });
                        }
                    }
                }

                await Task.Delay(TimeSpan.FromHours(1), stoppingToken);
            }
        }
    }
}
