using Microsoft.EntityFrameworkCore;
using ContratacaoService.Domain.Entities;
using ContratacaoService.Domain.Ports;

namespace ContratacaoService.Persistence.Repositories;

public class ContratacaoRepository : IContratacaoRepository
{
    private readonly ContratacoesDbContext _ctx;
    public ContratacaoRepository(ContratacoesDbContext ctx) => _ctx = ctx;

    public async Task AdicionarAsync(Contratacao c)
    {
        _ctx.Contratacoes.Add(c);
        await _ctx.SaveChangesAsync();
    }

    public Task<List<Contratacao>> ListarAsync() =>
        _ctx.Contratacoes.AsNoTracking().OrderByDescending(c => c.Data).ToListAsync();
}