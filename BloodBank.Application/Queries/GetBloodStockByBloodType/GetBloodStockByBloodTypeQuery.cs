using BloodBank.Application.Abstractions;
using BloodBank.Application.ViewModels;
using BloodBank.Core.Enums;
using MediatR;

namespace BloodBank.Application.Queries.GetBloodStockByBloodType
{
    public class GetBloodStockByBloodTypeQuery : IRequest<Result<BloodStockViewModel>>
    {
        public GetBloodStockByBloodTypeQuery(BloodType bloodType, RHFactor rhFactor)
        {
            BloodType = bloodType;
            RHFactor = rhFactor;
        }

        public BloodType BloodType { get; set; }
        public RHFactor RHFactor { get; set; }
    }
}