using Microsoft.EntityFrameworkCore;
using ContratacaoService.Domain.Entities;

namespace ContratacaoService.Persistence;

public class ContratacoesDbContext : DbContext
{
    public ContratacoesDbContext(DbContextOptions<ContratacoesDbContext> options) : base(options) { }
    public DbSet<Contratacao> Contratacoes => Set<Contratacao>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Contratacao>(e =>
        {
            e.HasKey(p => p.Id);
            e.Property(p => p.PropostaId).IsRequired();
            e.Property(p => p.Data).IsRequired();
        });
    }
}