using MediatR;
using SupportRequestManagement.Application.Features.Auth.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportRequestManagement.Application.Features.Auth.Commands
{
    internal class LoginCommand : IRequest<LoginResponseDto>
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
