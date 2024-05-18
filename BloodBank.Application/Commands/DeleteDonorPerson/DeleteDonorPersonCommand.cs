using MediatR;

namespace BloodBank.Application.Commands.DeleteDonorPerson
{
    public class DeleteDonorPersonCommand : IRequest<Unit>
    {
        public DeleteDonorPersonCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}