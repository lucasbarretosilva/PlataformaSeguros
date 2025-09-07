using System;
using FluentAssertions;
using ContratacaoService.Domain.Entities;
using Xunit;

namespace ContratacaoService.Domain.Tests;

public class ContratacaoTests
{
    [Fact]
    public void Criar_DeveGerarIdEManterPropostaId()
    {
        var pid = Guid.NewGuid();
        var c = Contratacao.Criar(pid, DateTime.UtcNow);

        c.Id.Should().NotBe(Guid.Empty);
        c.PropostaId.Should().Be(pid);
    }
}