using Rijschool.Shared.DTOs.Rijles;
using System.Net.Http.Json;

namespace Rijschool.Frontend.Services
{
    public class RijlesService
    {
        private readonly HttpClient _http;

        public RijlesService(HttpClient http)
        {
            _http = http;
        }

        public async Task<IEnumerable<RijlesDto>> GetRijlessenVoorLeerling(int leerlingId)
        {
            return await _http.GetFromJsonAsync<IEnumerable<RijlesDto>>($"api/rijles/leerling/{leerlingId}");
        }

        public async Task<IEnumerable<RijlesDto>> GetRijlessenVoorInstructeur(int instructeurId)
        {
            return await _http.GetFromJsonAsync<IEnumerable<RijlesDto>>($"api/rijles/instructeur/{instructeurId}");
        }


        public async Task WijzigOphaaladres(int rijlesId, string nieuwAdres)
        {
            var response = await _http.PutAsJsonAsync($"api/rijles/{rijlesId}/ophaaladres", nieuwAdres);
            response.EnsureSuccessStatusCode();
        }

        public async Task<bool> AnnuleerRijles(int rijlesId)
        {
            var response = await _http.PutAsync($"api/rijles/{rijlesId}/annuleren", null);
            return response.IsSuccessStatusCode;
        }
    }
}
