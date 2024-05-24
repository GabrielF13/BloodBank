using BloodBank.Application.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
