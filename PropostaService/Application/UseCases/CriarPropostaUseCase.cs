using PropostaService.Domain.Entities;
using PropostaService.Domain.Ports;

namespace PropostaService.Application.UseCases;

public sealed class CriarPropostaUseCase
{
    private readonly IPropostaRepository _repo;
    public CriarPropostaUseCase(IPropostaRepository repo) => _repo = repo;

    public async Task<Proposta> ExecutarAsync(string cliente, decimal valor)
    {
        var proposta = Proposta.Criar(cliente, valor);
        await _repo.AdicionarAsync(proposta);
        return proposta;
    }
}