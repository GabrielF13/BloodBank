using BloodBank.Application.Commands.CreateBloodStock;
using BloodBank.Application.Queries.GetAllBloodStock;
using BloodBank.Application.Queries.GetBloodStockByBloodType;
using BloodBank.Application.Queries.GetBloodStockById;
using BloodBank.Core.Enums;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BloodBank.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BloodStockController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BloodStockController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var getAllBloodStock = new GetAllBloodStockQuery();

            var viewModel = _mediator.Send(getAllBloodStock);

            return Ok(viewModel.Result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetBloodStockByIdQuery(id);

            var viewModel = await _mediator.Send(query);

            return Ok(viewModel);
        }

        [HttpGet("getByBloodTyp/{bloodType}")]
        public async Task<IActionResult> GetByBloodType(BloodType bloodType)
        {
            var query = new GetBloodStockByBloodTypeQuery(bloodType);

            var viewModel = await _mediator.Send(query);

            return Ok(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateBloodStockCommand command)
        {
            var id = await _mediator.Send(command);

            return Ok(id);
        }
    }
}