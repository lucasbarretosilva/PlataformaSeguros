using PropostaService.Domain.Ports;
using PropostaService.Domain.Entities;

namespace PropostaService.Application.UseCases;

public sealed class ListarPropostasUseCase
{
    private readonly IPropostaRepository _repo;
    public ListarPropostasUseCase(IPropostaRepository repo) => _repo = repo;

    public Task<List<Proposta>> ExecutarAsync() => _repo.ListarAsync();
}