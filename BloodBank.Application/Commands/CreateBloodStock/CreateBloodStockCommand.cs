using BloodBank.Core.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Application.Commands.CreateBloodStock
{
    public class CreateBloodStockCommand : IRequest<int>
    {
        public BloodType BloodType { get; set; }
        public RHFactor RhFactor { get; set; }
        public int QuantityMl { get; set; }
    }
}
