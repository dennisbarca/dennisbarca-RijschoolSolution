using System.Net.Http;
using System.Net.Http.Json;
using Rijschool.Shared.DTOs.Ziekmelding;

namespace Rijschool.Frontend.Services
{
    public class ZiekmeldingService
    {
        private readonly HttpClient _http;

        public ZiekmeldingService(HttpClient http)
        {
            _http = http;
        }

        // 🔹 Alle ziekmeldingen (admin / test)
        public async Task<IEnumerable<ZiekmeldingDto>> GetAlleZiekmeldingen()
        {
            return await _http.GetFromJsonAsync<IEnumerable<ZiekmeldingDto>>("api/ziekmelding");
        }

        // 🔹 Ziekmeldingen van instructeur
        public async Task<IEnumerable<ZiekmeldingDto>> GetZiekmeldingenVoorInstructeur(int instructeurId)
        {
            return await _http.GetFromJsonAsync<IEnumerable<ZiekmeldingDto>>(
                $"api/ziekmelding/instructeur/{instructeurId}");
        }

        // 🔹 Ziekmelding aanmaken
        public async Task<ZiekmeldingDto> Ziekmelden(CreateZiekmeldingDto dto)
        {
            var response = await _http.PostAsJsonAsync("api/ziekmelding", dto);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<ZiekmeldingDto>();
        }
    }
}
