using BloodBank.Application.Abstractions;
using BloodBank.Application.ViewModels;
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

        public LoginUserCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<LoginUserViewModel>> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var passwordHash = _unitOfWork.AuthService.ComputeSha256Hash(request.Password);

            var user = await _unitOfWork.DonorPersons.GetByEmailAndPasswordAsync(request.Email, passwordHash);

            if (user == null)
                return Result<LoginUserViewModel>.Failure("Email ou Senha errados!");

            var token = _unitOfWork.AuthService.GenerateJwtToken(user.Email, user.Role);

            var loginViewModel = new LoginUserViewModel(user.Email, token);

            return Result<LoginUserViewModel>.Success(loginViewModel,"Login realizado com sucesso!");
        }
    }
}
