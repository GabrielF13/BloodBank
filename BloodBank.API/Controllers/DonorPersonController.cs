using BloodBank.Application.Commands.CreateDonorPerson;
using BloodBank.Application.Commands.DeleteDonorPerson;
using BloodBank.Application.Commands.UpdateDonorPerson;
using BloodBank.Application.Queries.GetAllDonorPersons;
using BloodBank.Application.Queries.GetDonorPersonById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BloodBank.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonorPersonController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DonorPersonController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var GetAllDonorPersons = new GetAllDonorPersonsQuery();

            _mediator.Send(GetAllDonorPersons);

            return Ok(GetAllDonorPersons);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var command = new GetDonorPersonByIdQuery(id);

            await _mediator.Send(command);

            return Ok(command);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateDonorPersonCommand command)
        {
            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id }, command);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateDonorPersonCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteDonorPersonCommand(id);

            await _mediator.Send(command);

            return NoContent();
        }
    }
}