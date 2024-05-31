using BloodBank.Application.Commands.CreateDonate;
using BloodBank.Application.Queries.GetAllDonate;
using BloodBank.Application.Queries.GetDonateById;
using MediatR;
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

            var result = await _mediator.Send(getAllDonates);

            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var donate = new GetDonateByIdQuery(id);

            var result = await _mediator.Send(donate);

            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateDonateCommand command)
        {
            var result = await _mediator.Send(command);

            return result.IsSuccess ? Created(result.Message, result.Data) : BadRequest(result.Message);
        }
    }
}