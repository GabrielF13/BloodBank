using BloodBank.Application.ViewModels;
using BloodBank.Core.Enums;
using BloodBank.Core.Repositories;
using MediatR;
using System.Reflection;

namespace BloodBank.Application.Queries.GetAllDonorPersons
{
    public class GetAllDonorPersonsQueryHandler : IRequestHandler<GetAllDonorPersonsQuery, List<DonorPersonViewModel>>
    {
        private readonly IDonorPersonRepository _repository;

        public GetAllDonorPersonsQueryHandler(IDonorPersonRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<DonorPersonViewModel>> Handle(GetAllDonorPersonsQuery request, CancellationToken cancellationToken)
        {
            var donorPersons = await _repository.GetAllAsync();

            var donorPersonViewModels = donorPersons.Select( p => new DonorPersonViewModel(p.Id, p.FullName, p.Email, p.BirthDate, p.Gender, p.Weight, p.BloodType, p.RhFactor)).ToList();

            return donorPersonViewModels;
        }
    }
}