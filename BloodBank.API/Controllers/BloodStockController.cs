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
        public async Task<IActionResult> Get()
        {
            var getAllBloodStock = new GetAllBloodStockQuery();

            var result = await _mediator.Send(getAllBloodStock);

            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetBloodStockByIdQuery(id);

            var result = await _mediator.Send(query);

            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getByBloodTyp/{bloodType}")]
        public async Task<IActionResult> GetByBloodType(BloodType bloodType, RHFactor rHFactor)
        {
            var query = new GetBloodStockByBloodTypeQuery(bloodType, rHFactor);

            var result = await _mediator.Send(query);

            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateBloodStockCommand command)
        {
            var result = await _mediator.Send(command);

            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
    }
}