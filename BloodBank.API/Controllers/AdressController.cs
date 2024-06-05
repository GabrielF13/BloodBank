using BloodBank.Application.Commands.CreateAdress;
using BloodBank.Infrastructure.CEP;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Runtime.ConstrainedExecution;

namespace BloodBank.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdressController : ControllerBase
    {
        private readonly ViaCEP _viaCEP;
        private readonly IMediator _mediator;

        public AdressController(ViaCEP viaCEP, IMediator mediator)
        {
            _viaCEP = viaCEP;
            _mediator = mediator;
        }

        [HttpGet("{cep}")]
        public async Task<IActionResult> GetEndereco(string cep)
        {
            var endereco = await _viaCEP.ObterEnderecoPorCepAsync(cep);

            if (endereco == null)
            {
                return NotFound();
            }

            return Ok(endereco);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateAdressCommand command)
        {
            var result = await _mediator.Send(command);

            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

    }
}
