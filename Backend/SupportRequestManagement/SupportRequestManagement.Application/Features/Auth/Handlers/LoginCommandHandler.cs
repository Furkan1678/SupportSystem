using BCrypt.Net;
using MediatR;
using SupportRequestManagement.Application.Features.Auth.Commands;
using SupportRequestManagement.Application.Features.Auth.Dtos;
using SupportRequestManagement.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportRequestManagement.Application.Features.Auth.Handlers
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginResponseDto>

    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtTokenService _jwtTokenService;

        public LoginCommandHandler(IUserRepository userRepository, IJwtTokenService jwtTokenService)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _jwtTokenService = jwtTokenService ?? throw new ArgumentNullException(nameof(jwtTokenService));
        }

        public async Task<LoginResponseDto> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            if (request == null || string.IsNullOrEmpty(request.Username) || string.IsNullOrEmpty(request.Password))
            {
                throw new ArgumentException("Kullanıcı adı veya şifre boş olamaz.");
            }

            var user = await _userRepository.GetByUsernameAsync(request.Username);
            if (user == null)
            {
                Console.WriteLine($"Kullanıcı bulunamadı: {request.Username}");
                throw new UnauthorizedAccessException("Kullanıcı bulunamadı.");
            }

            Console.WriteLine($"Kullanıcı bulundu: Id={user.Id}, Username={user.Username}, Hash={user.PasswordHash}");
            if (string.IsNullOrEmpty(user.PasswordHash))
            {
                Console.WriteLine($"Şifre hash’i boş: {request.Username}");
                throw new UnauthorizedAccessException("Geçersiz kimlik bilgileri: Şifre hash’i yok.");
            }

            var isValid = BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash);
            Console.WriteLine($"BCrypt Verify: {isValid}, Girilen Şifre: {request.Password}, Hash: {user.PasswordHash}");
            if (!isValid)
            {
                throw new UnauthorizedAccessException("Geçersiz kimlik bilgileri: Şifre doğrulanamadı.");
            }

            user.LastLogin = DateTime.UtcNow;
            await _userRepository.UpdateAsync(user);

            var token = _jwtTokenService.GenerateToken(user);
            if (string.IsNullOrEmpty(token))
            {
                throw new InvalidOperationException("Token oluşturulamadı.");
            }

            return new LoginResponseDto { Token = token, UserId = user.Id, Role = user.Role };
        }
    }
}
