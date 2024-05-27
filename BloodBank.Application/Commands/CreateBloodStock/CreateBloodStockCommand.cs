﻿using BloodBank.Core.Enums;
using MediatR;

namespace BloodBank.Application.Commands.CreateBloodStock
{
    public class CreateBloodStockCommand : IRequest<int>
    {
        public BloodType BloodType { get; set; }
        public RHFactor RhFactor { get; set; }
        public int QuantityMl { get; set; }
    }
}