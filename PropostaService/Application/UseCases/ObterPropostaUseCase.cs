using PropostaService.Domain.Ports;
using PropostaService.Domain.Entities;

namespace PropostaService.Application.UseCases;

public sealed class ObterPropostaUseCase
{
    private readonly IPropostaRepository _repo;
    public ObterPropostaUseCase(IPropostaRepository repo) => _repo = repo;

    public Task<Proposta?> ExecutarAsync(Guid id) => _repo.ObterPorIdAsync(id);
}