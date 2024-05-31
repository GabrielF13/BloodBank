using BloodBank.Application.Abstractions;
using BloodBank.Application.ViewModels;
using MediatR;

namespace BloodBank.Application.Queries.GetDonorPersonById
{
    public class GetDonorPersonByIdQuery : IRequest<Result<DonorPersonViewModel>>
    {
        public GetDonorPersonByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}