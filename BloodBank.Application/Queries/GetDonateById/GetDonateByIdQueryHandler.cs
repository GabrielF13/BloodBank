using BloodBank.Application.Abstractions;
using BloodBank.Application.ViewModels;
using BloodBank.Infrastructure.Persistence;
using MediatR;

namespace BloodBank.Application.Queries.GetDonateById
{
    public class GetDonateByIdQueryHandler : IRequestHandler<GetDonateByIdQuery, Result<DonationViewModel>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetDonateByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<DonationViewModel>> Handle(GetDonateByIdQuery request, CancellationToken cancellationToken)
        {
            var donate = await _unitOfWork.Donates.GetById(request.Id);

            if (donate == null)
                return Result<DonationViewModel>.NotFound("Doação não encontrada");

            var donateViewModel = new DonationViewModel(donate.Id, donate.DonorId, donate.DateDonation, donate.QuantityMl);

            return Result<DonationViewModel>.Success(donateViewModel);
        }
    }
}