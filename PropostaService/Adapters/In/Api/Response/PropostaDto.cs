using PropostaService.Domain.Entities;

namespace PropostaService.Api.Response
{
    public record PropostaDto(Guid Id, string Cliente, decimal Valor, int IdStatus, DateTime CriadoEm, string Status)
    {
        public PropostaDto(Proposta p) : this(p.Id, p.Cliente, p.Valor, p.IdStatusProposta, p.CriadoEm, p.StatusProposta?.Nome) { }
    }
}
