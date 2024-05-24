using BloodBank.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Application.Commands.CreateDonate
{
    public class CreateDonateCommand : IRequest<int>
    {
        public DateTime DateDonation { get; private set; }
        public int QuantityMl { get; private set; }
        public int DonorPersonId { get; private set; }
    }
}
