using BloodBank.Application.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Application.Queries.GetDonorPersonById
{
    public class GetDonorPersonByIdQuery : IRequest<DonorPersonViewModel>
    {
        public GetDonorPersonByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
