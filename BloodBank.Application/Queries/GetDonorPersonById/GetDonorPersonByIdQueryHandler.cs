using BloodBank.Application.Abstractions;
using BloodBank.Application.ViewModels;
using BloodBank.Infrastructure.Persistence;
using MediatR;

namespace BloodBank.Application.Queries.GetDonorPersonById
{
    public class GetDonorPersonByIdQueryHandler : IRequestHandler<GetDonorPersonByIdQuery, Result<DonorPersonViewModel>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetDonorPersonByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<DonorPersonViewModel>> Handle(GetDonorPersonByIdQuery request, CancellationToken cancellationToken)
        {
            var person = await _unitOfWork.DonorPersons.GetByIdAsync(request.Id);

            if (person == null)
                return Result<DonorPersonViewModel>.NotFound("Usuario não encontrado");

            var donorPersonviewModel = new DonorPersonViewModel
                (
                    person.Id,
                    person.FullName,
                    person.Email,
                    person.BirthDate,
                    person.Gender,
                    person.Weight,
                    person.BloodType,
                    person.RhFactor
                );

            return Result<DonorPersonViewModel>.Success(donorPersonviewModel);
        }
    }
}