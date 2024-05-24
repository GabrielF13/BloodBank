using BloodBank.Application.ViewModels;
using MediatR;

namespace BloodBank.Application.Queries.GetAllBloodStock
{
    public class GetAllBloodStockQuery : IRequest<List<BloodStockViewModel>>
    {
    }
}