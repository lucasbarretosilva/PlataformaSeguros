using PropostaService.Domain.Enum;

namespace PropostaService.Domain.Entities;
public sealed class Proposta
{
    public Guid Id { get; private set; }
    public string Cliente { get; private set; }
    public decimal Valor { get; private set; }
    public int IdStatusProposta { get; private set; }
    public DateTime CriadoEm { get; private set; }


    public StatusProposta StatusProposta { get; private set; }
    

    private Proposta() { } 
    private Proposta(string cliente, decimal valor)
    {
        Id = Guid.NewGuid();
        Cliente = cliente;
        Valor = valor;
        IdStatusProposta = (int)StatusPropostaEnum.EmAnalise;
        CriadoEm = DateTime.Now;
    }

    public static Proposta Criar(string cliente, decimal valor)
    {
        if (string.IsNullOrWhiteSpace(cliente)) throw new ArgumentException("Cliente obrigatório");
        if (valor <= 0) throw new ArgumentException("Valor deve ser maior que 0");
        return new Proposta(cliente, valor);
    }

    public void AlterarStatus(int novo)
    {
        IdStatusProposta = novo;
    }
}
