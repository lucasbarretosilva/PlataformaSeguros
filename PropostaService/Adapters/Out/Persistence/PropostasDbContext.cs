using Microsoft.EntityFrameworkCore;
using PropostaService.Domain.Entities;
using PropostaService.Domain.Enum;

namespace PropostaService.Persistence;

public class PropostasDbContext : DbContext
{
    public PropostasDbContext(DbContextOptions<PropostasDbContext> options) : base(options) { }
    public DbSet<Proposta> Propostas => Set<Proposta>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Proposta>(e =>
        {
            e.HasKey(p => p.Id);
            e.Property(p => p.Cliente).IsRequired().HasMaxLength(200);
            e.Property(p => p.Valor).HasPrecision(18,2);
            e.Property(p => p.IdStatusProposta).IsRequired();
            e.Property(p => p.CriadoEm).IsRequired();
            e.HasOne(p => p.StatusProposta).WithMany().HasForeignKey(x => x.IdStatusProposta);
        });

        modelBuilder.Entity<StatusProposta>(e =>
        {
            e.HasKey(p => p.Id);
            e.Property(p => p.Nome);
        });

        modelBuilder.Entity<StatusProposta>().HasData(
            new StatusProposta()
            {
                Id = (int)StatusPropostaEnum.EmAnalise,
                Nome = "Em análise"
            },
            new StatusProposta()
            {
                Id = (int)StatusPropostaEnum.Aprovada,
                Nome = "Aprovada"
            },
            new StatusProposta()
            {
                Id = (int)StatusPropostaEnum.Rejeitada,
                Nome = "Rejeitada"
            }
            );
    }
}
