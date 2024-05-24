using BloodBank.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Application.Commands.UpdateDonate
{
    public class UpdateDonateCommandHandler : IRequestHandler<UpdateDonateCommand, Unit>
    {
        private readonly IDonateRepository _repository;

        public UpdateDonateCommandHandler(IDonateRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateDonateCommand request, CancellationToken cancellationToken)
        {
            var donate = await _repository.GetById(request.Id);

            if (donate == null)
               
                
            //return ValueTask.CompletedTask();


        }
    }
}
