using PropostaService.Domain.Ports;
using PropostaService.Domain.Entities;

namespace PropostaService.Application.UseCases;

public sealed class AlterarStatusUseCase
{
    private readonly IPropostaRepository _repo;
    public AlterarStatusUseCase(IPropostaRepository repo) => _repo = repo;

    public async Task<Proposta?> ExecutarAsync(Guid id, int novoStatus)
    {
        var proposta = await _repo.ObterPorIdAsync(id);
        if (proposta is null) return null;
        proposta.AlterarStatus(novoStatus);
        await _repo.AtualizarAsync(proposta);
        return proposta;
    }
}
