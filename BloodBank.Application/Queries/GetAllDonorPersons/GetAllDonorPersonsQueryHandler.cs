using BloodBank.Application.Abstractions;
using BloodBank.Application.ViewModels;
using BloodBank.Infrastructure.Persistence;
using MediatR;

namespace BloodBank.Application.Queries.GetAllDonorPersons
{
    public class GetAllDonorPersonsQueryHandler : IRequestHandler<GetAllDonorPersonsQuery, Result<List<DonorPersonViewModel>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllDonorPersonsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<List<DonorPersonViewModel>>> Handle(GetAllDonorPersonsQuery request, CancellationToken cancellationToken)
        {
            var donorPersons = await _unitOfWork.DonorPersons.GetAllAsync();

            var donorPersonViewModels = donorPersons.Select(p => new DonorPersonViewModel(p.Id, p.FullName, p.Email, p.BirthDate, p.Gender, p.Weight, p.BloodType, p.RhFactor)).ToList();

            return Result<List<DonorPersonViewModel>>.Success(donorPersonViewModels);
        }
    }
}