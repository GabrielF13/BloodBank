using BloodBank.Application.ViewModels;
using BloodBank.Core.Repositories;
using MediatR;

namespace BloodBank.Application.Queries.GetDonateById
{
    public class GetDonateByIdQueryHandler : IRequestHandler<GetDonateByIdQuery, DonationViewModel>
    {
        private readonly IDonateRepository _repository;

        public GetDonateByIdQueryHandler(IDonateRepository repository)
        {
            _repository = repository;
        }

        public async Task<DonationViewModel> Handle(GetDonateByIdQuery request, CancellationToken cancellationToken)
        {
            var donate = await _repository.GetById(request.Id);

            if (donate == null)
                return null;

            var donateViewModel = new DonationViewModel(donate.Id, donate.DonorId, donate.DateDonation, donate.QuantityMl);

            return donateViewModel;
        }
    }
}