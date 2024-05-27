using BloodBank.Core.Repositories;
using MediatR;

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

            return Unit.Value;
        }
    }
}