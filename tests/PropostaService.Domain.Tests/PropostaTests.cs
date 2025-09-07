using System;
using FluentAssertions;
using PropostaService.Domain.Entities;
using PropostaService.Domain.Enum;
using Xunit;

namespace PropostaService.Domain.Tests;

public class PropostaTests
{
    [Fact]
    public void CriarProposta_ComDadosValidos_DeveIniciarEmAnalise()
    {
        var p = Proposta.Criar("Cliente A", 100m);
        p.Id.Should().NotBe(Guid.Empty);
        p.Cliente.Should().Be("Cliente A");
        p.Valor.Should().Be(100m);
        p.IdStatusProposta.Should().Be((int)StatusPropostaEnum.EmAnalise);
        p.CriadoEm.Should().BeOnOrBefore(DateTime.UtcNow);
    }

    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    public void CriarProposta_ClienteInvalido_DeveLancar(string cliente)
    {
        Action act = () => Proposta.Criar(cliente, 10m);
        act.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void CriarProposta_ValorNaoPositivo_DeveLancar()
    {
        Action act = () => Proposta.Criar("OK", 0m);
        act.Should().Throw<ArgumentException>();
    }
}
