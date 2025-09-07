
using PropostaService.Domain.Entities;

namespace PropostaService.Domain.Ports;

public interface IPropostaRepository
{
    Task<Proposta?> ObterPorIdAsync(Guid id);
    Task<List<Proposta>> ListarAsync();
    Task AdicionarAsync(Proposta proposta);
    Task AtualizarAsync(Proposta proposta);
}
