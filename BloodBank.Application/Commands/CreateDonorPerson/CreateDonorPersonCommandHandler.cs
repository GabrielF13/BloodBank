using BloodBank.Application.Abstractions;
using BloodBank.Core.Entities;
using BloodBank.Core.Services;
using BloodBank.Infrastructure.Persistence;
using MediatR;

namespace BloodBank.Application.Commands.CreateDonorPerson
{
    public class CreateDonorPersonCommandHandler : IRequestHandler<CreateDonorPersonCommand, Result<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAuthService _authService;

        public CreateDonorPersonCommandHandler(IUnitOfWork unitOfWork, IAuthService authService)
        {
            _unitOfWork = unitOfWork;
            _authService = authService;
        }

        public async Task<Result<int>> Handle(CreateDonorPersonCommand request, CancellationToken cancellationToken)
        {

            var passwordHash = _authService.ComputeSha256Hash(request.Password);

            var donorPerson = new DonorPerson(request.FullName, request.Email, request.BirthDate, request.Gender, request.Weight, request.BloodType, request.RhFactor, passwordHash, request.Role);

            var emailExists = await _unitOfWork.DonorPersons.GetByEmailAsync(donorPerson.Email);

            if (emailExists != null)
                return Result<int>.Failure("Email já cadastrado em outra conta");

            await _unitOfWork.DonorPersons.AddAsync(donorPerson);

            await _unitOfWork.CompleteAsync();

            return Result<int>.Success(donorPerson.Id, "Usuario criado com sucesso.");
        }
    }
}