using BloodBank.Application.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Application.Queries.GetAllDonorPersons
{
    public class GetAllDonorPersonsQuery : IRequest<List<DonorPersonViewModel>>
    {
    }
}
