namespace ContratacaoService.Domain.Ports;

public interface IPropostaStatusGateway
{
    Task<string?> ObterStatusAsync(Guid propostaId); // retorna "EmAnalise" | "Aprovada" | "Rejeitada"
}