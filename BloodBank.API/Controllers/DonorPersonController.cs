using BloodBank.Application.Abstractions;
using BloodBank.Application.Commands.CreateDonorPerson;
using BloodBank.Application.Commands.DeleteDonorPerson;
using BloodBank.Application.Commands.LoginUser;
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

            var result = await _mediator.Send(GetAllDonorPersons);

            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var command = new GetDonorPersonByIdQuery(id);

            var result = await _mediator.Send(command);

            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateDonorPersonCommand command)
        {
            var result = await _mediator.Send(command);

            return result.IsSuccess ? Created(result.Message, result.Data) : BadRequest(result.Message);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateDonorPersonCommand command)
        {
            var result = await _mediator.Send(command);

            return result.IsSuccess ? Created(result.Message, result.Data) : BadRequest(result.Message);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteDonorPersonCommand(id);

            var result = await _mediator.Send(command);

            return result.IsSuccess ? Created(result.Message, result.Data) : BadRequest(result.Message);
        }

        [HttpPut("Login")]
        public async Task<IActionResult> Login([FromBody] LoginUserCommand command)
        {
            var result = await _mediator.Send(command);

            return result.IsSuccess ? Created(result.Message, result.Data) : BadRequest(result.Message);
        }
    }
}