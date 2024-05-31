using BloodBank.Application.Abstractions;
using BloodBank.Application.ViewModels;
using MediatR;

namespace BloodBank.Application.Queries.GetDonateById
{
    public class GetDonateByIdQuery : IRequest<Result<DonationViewModel>>
    {
        public GetDonateByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}