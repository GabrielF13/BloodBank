using BloodBank.Application.Abstractions;
using BloodBank.Application.ViewModels;
using BloodBank.Core.Services;
using BloodBank.Infrastructure.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Application.Commands.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, Result<LoginUserViewModel>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAuthService _authService;

        public LoginUserCommandHandler(IUnitOfWork unitOfWork, IAuthService authService)
        {
            _unitOfWork = unitOfWork;
            _authService = authService;
        }

        public async Task<Result<LoginUserViewModel>> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var passwordHash = _authService.ComputeSha256Hash(request.Password);

            var user = await _unitOfWork.DonorPersons.GetByEmailAndPasswordAsync(request.Email, passwordHash);

            if (user == null)
                return Result<LoginUserViewModel>.Failure("Email ou Senha errados!");

            var token = _authService.GenerateJwtToken(user.Email, user.Role);

            var loginViewModel = new LoginUserViewModel(user.Email, token);

            return Result<LoginUserViewModel>.Success(loginViewModel,"Login realizado com sucesso!");
        }
    }
}
