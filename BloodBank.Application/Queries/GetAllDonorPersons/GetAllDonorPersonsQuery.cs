using BloodBank.Application.Abstractions;
using BloodBank.Application.ViewModels;
using MediatR;

namespace BloodBank.Application.Queries.GetAllDonorPersons
{
    public class GetAllDonorPersonsQuery : IRequest<Result<List<DonorPersonViewModel>>>
    {
    }
}