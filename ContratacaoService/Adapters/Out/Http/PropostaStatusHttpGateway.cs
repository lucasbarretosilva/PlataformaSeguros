using System.Net.Http.Json;
using ContratacaoService.Domain.Ports;

namespace ContratacaoService.Http;

public class PropostaStatusHttpGateway : IPropostaStatusGateway
{
    private readonly HttpClient _http;
    public PropostaStatusHttpGateway(HttpClient http) => _http = http;

    public async Task<string?> ObterStatusAsync(Guid propostaId)
    {
        var resp = await _http.GetAsync($"/propostas/{propostaId}");
        if (!resp.IsSuccessStatusCode) return null;
        var doc = await resp.Content.ReadFromJsonAsync<PropostaDto>();
        return doc?.status;
    }

    private record PropostaDto(Guid id, string cliente, decimal valor, string status, DateTime criadoEm);
}