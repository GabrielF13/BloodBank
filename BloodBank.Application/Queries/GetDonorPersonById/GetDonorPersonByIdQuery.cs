using BloodBank.Application.ViewModels;
using MediatR;

namespace BloodBank.Application.Queries.GetDonorPersonById
{
    public class GetDonorPersonByIdQuery : IRequest<DonorPersonViewModel>
    {
        public GetDonorPersonByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}