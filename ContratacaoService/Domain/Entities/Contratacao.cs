namespace ContratacaoService.Domain.Entities;

public sealed class Contratacao
{
    public Guid Id { get; private set; }
    public Guid PropostaId { get; private set; }
    public DateTime Data { get; private set; }

    private Contratacao() { } // EF
    private Contratacao(Guid propostaId, DateTime data)
    {
        Id = Guid.NewGuid();
        PropostaId = propostaId;
        Data = data;
    }

    public static Contratacao Criar(Guid propostaId, DateTime data) => new(propostaId, data);
}