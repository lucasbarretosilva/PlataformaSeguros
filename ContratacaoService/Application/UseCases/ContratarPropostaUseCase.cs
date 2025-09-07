using ContratacaoService.Domain.Entities;
using ContratacaoService.Domain.Ports;

namespace ContratacaoService.Application.UseCases;

public sealed class ContratarPropostaUseCase
{
    private readonly IPropostaStatusGateway _gateway;
    private readonly IContratacaoRepository _repo;

    public ContratarPropostaUseCase(IPropostaStatusGateway gateway, IContratacaoRepository repo)
    {
        _gateway = gateway;
        _repo = repo;
    }

    public async Task<Contratacao?> ExecutarAsync(Guid propostaId)
    {
        var status = await _gateway.ObterStatusAsync(propostaId);
        if (status is null) throw new InvalidOperationException("Proposta não encontrada");
        if (!string.Equals(status, "Aprovada", StringComparison.OrdinalIgnoreCase))
            throw new InvalidOperationException("Proposta não aprovada");

        var c = Contratacao.Criar(propostaId, DateTime.UtcNow);
        await _repo.AdicionarAsync(c);
        return c;
    }
}