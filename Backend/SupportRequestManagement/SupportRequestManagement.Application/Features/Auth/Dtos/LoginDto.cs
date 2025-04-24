using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportRequestManagement.Application.Features.Auth.Dtos
{
    public class LoginDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
