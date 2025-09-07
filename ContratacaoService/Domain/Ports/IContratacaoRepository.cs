using ContratacaoService.Domain.Entities;

namespace ContratacaoService.Domain.Ports;

public interface IContratacaoRepository
{
    Task AdicionarAsync(Contratacao c);
    Task<List<Contratacao>> ListarAsync();
}