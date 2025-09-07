using ContratacaoService.Domain.Entities;

namespace ContratacaoService.Api.Responses
{
    public record ContratacaoDto(Guid Id, Guid PropostaId, DateTime Data)
    {
        public ContratacaoDto(Contratacao c) : this(c.Id, c.PropostaId, c.Data) { }
    }
}
