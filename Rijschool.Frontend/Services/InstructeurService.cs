using Rijschool.Shared.DTOs.Instructeur;
using System.Net.Http.Json;

public class InstructeurService
{
    private readonly HttpClient _http;

    public InstructeurService(HttpClient http)
    {
        _http = http;
    }

    public async Task<InstructeurDto> GetInstructeur(int id)
    {
        return await _http.GetFromJsonAsync<InstructeurDto>($"api/instructeur/{id}");
    }
}
