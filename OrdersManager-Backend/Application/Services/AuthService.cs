using Core.Models;
using Core.Repositories;
using Core.Services;
using System.Security.Claims;

namespace Application.Services
{
    public class AuthService : IAuthService
    {

        private readonly IAuthRepository _authRepository;
        private readonly ITokenService _tokenService;

        public AuthService(IAuthRepository authRepository, ITokenService tokenService)
        {
            _authRepository = authRepository;
            _tokenService = tokenService;
        }

        public string GetAuthenticatedUserId(ClaimsPrincipal User)
        {
            string? userId = User.FindFirst("id")?.Value;
            if (userId == null) {
              throw new Exception("User not found");
            }

            return userId;
        }

        public async Task<string> SignIn(string email, string password)
        {
            Customer? customer = await _authRepository.GetCustomerByEmailAndPassword(email, password);
            if (customer == null)
            {
                throw new Exception("Usuário e/ou senha inválidos");
            }

            string token = _tokenService.CreateCustomerToken(customer);

            return token;
        }

    }
}
