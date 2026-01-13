using Rijschool.Shared.DTOs.Examen;
using System.Net.Http.Json;

namespace Rijschool.Frontend.Services
{
    public class ExamenService
    {
        private readonly HttpClient _http;

        public ExamenService(HttpClient http)
        {
            _http = http;
        }

        public async Task<IEnumerable<ExamenDto>> GetExamensVoorLeerling(int leerlingId)
        {
            return await _http.GetFromJsonAsync<IEnumerable<ExamenDto>>($"api/leerling/{leerlingId}/examens");
        }

        public async Task<IEnumerable<ExamenDto>> GetExamensVoorInstructeur(int instructeurId)
        {
            return await _http.GetFromJsonAsync<IEnumerable<ExamenDto>>($"api/instructeur/{instructeurId}/examens");
        }
    }
}
