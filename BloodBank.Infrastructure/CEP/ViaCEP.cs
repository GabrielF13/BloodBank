using BloodBank.Core.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Infrastructure.CEP
{
    public class ViaCEP
    {
        private readonly HttpClient _httpClient;

        public ViaCEP(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Address> ObterEnderecoPorCepAsync(string cep)
        {
            var response = await _httpClient.GetAsync($"https://viacep.com.br/ws/{cep}/json/");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var endereco = JsonConvert.DeserializeObject<AdressCEP>(content);

            var adress = new Address(0, endereco.Logradouro, endereco.Localidade, endereco.Uf, endereco.Cep);

            return adress;
        }
    }
}