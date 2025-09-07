using Microsoft.EntityFrameworkCore;
using PropostaService.Domain.Entities;
using PropostaService.Domain.Ports;

namespace PropostaService.Persistence.Repositories;

public class PropostaRepository : IPropostaRepository
{
    private readonly PropostasDbContext _ctx;
    public PropostaRepository(PropostasDbContext ctx) => _ctx = ctx;

    public Task<Proposta?> ObterPorIdAsync(Guid id) =>
        _ctx.Propostas.Include(x => x.StatusProposta).FirstOrDefaultAsync(p => p.Id == id);

    public Task<List<Proposta>> ListarAsync() =>
        _ctx.Propostas.Include(x => x.StatusProposta).AsNoTracking().OrderByDescending(p => p.CriadoEm).ToListAsync();

    public async Task AdicionarAsync(Proposta proposta)
    {
        _ctx.Propostas.Add(proposta);
        await _ctx.SaveChangesAsync();
    }

    public async Task AtualizarAsync(Proposta proposta)
    {
        _ctx.Propostas.Update(proposta);
        await _ctx.SaveChangesAsync();
    }
}
