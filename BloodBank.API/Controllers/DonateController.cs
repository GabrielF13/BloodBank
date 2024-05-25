using BloodBank.Application.Commands.CreateDonate;
using BloodBank.Application.Queries.GetAllDonate;
using BloodBank.Application.Queries.GetAllDonorPersons;
using BloodBank.Application.Queries.GetDonateById;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BloodBank.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonateController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DonateController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var getAllDonates = new GetAllDonateQuery();

            var viewModels = await _mediator.Send(getAllDonates);

            return Ok(viewModels);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var donate = new GetDonateByIdQuery(id);

            var viewModel = await _mediator.Send(donate);

            return Ok(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateDonateCommand command)
        {
            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id }, command);
        }
    }
}
