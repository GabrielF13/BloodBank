using BloodBank.Application.Abstractions;
using BloodBank.Application.ViewModels;
using BloodBank.Infrastructure.Persistence;
using MediatR;

namespace BloodBank.Application.Queries.GetAllDonate
{
    public class GetAllDonateQueryHandler : IRequestHandler<GetAllDonateQuery, Result<List<DonationViewModel>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllDonateQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<List<DonationViewModel>>> Handle(GetAllDonateQuery request, CancellationToken cancellationToken)
        {
            var donates = await _unitOfWork.Donates.GetAll();

            var donateViewModels = donates.Select(
                p => new DonationViewModel(p.Id, p.DonorId, p.DateDonation, p.QuantityMl)).ToList();

            return Result<List<DonationViewModel>>.Success(donateViewModels);
        }
    }
}