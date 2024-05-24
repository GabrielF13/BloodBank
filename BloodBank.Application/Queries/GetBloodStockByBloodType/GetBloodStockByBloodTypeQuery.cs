using BloodBank.Application.ViewModels;
using BloodBank.Core.Enums;
using MediatR;

namespace BloodBank.Application.Queries.GetBloodStockByBloodType
{
    public class GetBloodStockByBloodTypeQuery : IRequest<List<BloodStockViewModel>>
    {
        public GetBloodStockByBloodTypeQuery(BloodType bloodType)
        {
            BloodType = bloodType;
        }

        public BloodType BloodType { get; set; }
    }
}