using BloodBank.Application.Abstractions;
using BloodBank.Application.ViewModels;
using MediatR;

namespace BloodBank.Application.Queries.GetAllDonate
{
    public class GetAllDonateQuery : IRequest<Result<List<DonationViewModel>>>
    {
    }
}