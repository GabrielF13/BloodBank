using BloodBank.Application.Commands.CreateAdress;
using BloodBank.Infrastructure.CEP;
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

        public AdressController(ViaCEP viaCEP)
        {
            _viaCEP = viaCEP;
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
            var adress = await _viaCEP.ObterEnderecoPorCepAsync(command.ZipCode);

            if (adress == null)
            {

            }

            return Ok();
        }

    }
}
