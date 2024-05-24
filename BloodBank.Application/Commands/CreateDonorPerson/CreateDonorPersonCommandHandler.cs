using BloodBank.Application.Errors;
using BloodBank.Core.Entities;
using BloodBank.Core.Entities.Errors;
using BloodBank.Core.Repositories;
using BloodBank.Core.Results;
using MediatR;
using System.Net;

namespace BloodBank.Application.Commands.CreateDonorPerson
{
    public class CreateDonorPersonCommandHandler : IRequestHandler<CreateDonorPersonCommand, Result<Guid>>
    {
        private readonly IDonorPersonRepository _repository;

        public CreateDonorPersonCommandHandler(IDonorPersonRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<Guid>> Handle(CreateDonorPersonCommand request, CancellationToken cancellationToken)
        {
            var donorPerson = new DonorPerson(request.FullName, request.Email, request.BirthDate, request.Gender, request.Weight, request.BloodType, request.RhFactor);

             var created = await _repository.AddAsync(donorPerson) > 0;

            if (!created)
                return Result.Fail<Guid>(new HttpStatusCodeError(DonorPersonErrors.CannotBeCreated, HttpStatusCode.InternalServerError));


            return Result.Ok(donorPerson.Id);
        }
    }
}