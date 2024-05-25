using BloodBank.Application.ViewModels;
using BloodBank.Core.Repositories;
using MediatR;

namespace BloodBank.Application.Queries.GetAllDonate
{
    public class GetAllDonateQueryHandler : IRequestHandler<GetAllDonateQuery, List<DonationViewModel>>
    {
        private readonly IDonateRepository _repository;

        public GetAllDonateQueryHandler(IDonateRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<DonationViewModel>> Handle(GetAllDonateQuery request, CancellationToken cancellationToken)
        {
            var donates = await _repository.GetAll();

            var donateViewModels = donates.Select(
                p => new DonationViewModel(p.Id, p.DonorId, p.DateDonation, p.QuantityMl)).ToList();

            return donateViewModels;
        }
    }
}