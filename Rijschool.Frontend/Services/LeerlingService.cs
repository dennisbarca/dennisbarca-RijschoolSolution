using Rijschool.Shared.DTOs.Leerling;
using System.Net.Http.Json;

namespace Rijschool.Frontend.Services
{
    public class LeerlingService
    {
        private readonly HttpClient _http;

        public LeerlingService(HttpClient http)
        {
            _http = http;
        }

        public async Task<LeerlingDto> GetLeerling(int leerlingId)
        {
            return await _http.GetFromJsonAsync<LeerlingDto>($"api/leerling/{leerlingId}");
        }

        public async Task UpdateLeerling(int leerlingId, UpdateLeerlingDto dto)
        {
            var response = await _http.PutAsJsonAsync($"api/leerling/{leerlingId}", dto);
            response.EnsureSuccessStatusCode();
        }
    }
}
