using BloodBank.Application.ViewModels;
using BloodBank.Core.Repositories;
using MediatR;

namespace BloodBank.Application.Queries.GetDonorPersonById
{
    public class GetDonorPersonByIdQueryHandler : IRequestHandler<GetDonorPersonByIdQuery, DonorPersonViewModel>
    {
        private readonly IDonorPersonRepository _repository;

        public async Task<DonorPersonViewModel> Handle(GetDonorPersonByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var person = await _repository.GetByIdAsync(request.Id);

                if (person == null)
                    return null;

                var donorPersonviewModel = new DonorPersonViewModel
                    (
                        person.Id,
                        person.FullName,
                        person.Email,
                        person.BirthDate,
                        person.Gender,
                        person.Weight,
                        person.BloodType,
                        person.RhFactor
                    );

                return donorPersonviewModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
    }
}