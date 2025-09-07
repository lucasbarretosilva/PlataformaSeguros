using ContratacaoService.Domain.Entities;
using ContratacaoService.Domain.Ports;

namespace ContratacaoService.Application.UseCases;

public sealed class ListarContratacoesUseCase
{
    private readonly IContratacaoRepository _repo;
    public ListarContratacoesUseCase(IContratacaoRepository repo) => _repo = repo;
    public Task<List<Contratacao>> ExecutarAsync() => _repo.ListarAsync();
}