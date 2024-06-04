using BloodBank.Application.Abstractions;
using BloodBank.Core.Entities;
using BloodBank.Infrastructure.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Application.Commands.CreateAdress
{
    public class CreateAdressCommandHandler : IRequestHandler<CreateAdressCommand, Result<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateAdressCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<int>> Handle(CreateAdressCommand request, CancellationToken cancellationToken)
        {
            var donor = await _unitOfWork.DonorPersons.GetByIdAsync(request.DonorId);

            if (donor == null)
                return Result<int>.Failure("Usuario não encontrado");

            var address = new Address(donor.Id, request.PublicPlace,request.City, request.State,request.ZipCode);

            await _unitOfWork.Adresses.AddAsync(address);

            await _unitOfWork.CompleteAsync();

            return Result<int>.Success(address.Id);
        }
    }
}
