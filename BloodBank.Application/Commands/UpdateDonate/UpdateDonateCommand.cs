using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Application.Commands.UpdateDonate
{
    public class UpdateDonateCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public int QuantityMl { get; set; }
    }
}
