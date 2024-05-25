using BloodBank.Application.ViewModels;
using MediatR;

namespace BloodBank.Application.Queries.GetAllDonate
{
    public class GetAllDonateQuery : IRequest<List<DonationViewModel>>
    {
    }
}