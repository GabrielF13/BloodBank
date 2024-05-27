using BloodBank.Application.ViewModels;
using MediatR;

namespace BloodBank.Application.Queries.GetBloodStockById
{
    public class GetBloodStockByIdQuery : IRequest<BloodStockViewModel>
    {
        public GetBloodStockByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}