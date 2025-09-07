using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using PropostaService.Application.UseCases;
using PropostaService.Domain.Entities;
using PropostaService.Domain.Enum;
using PropostaService.Domain.Ports;
using Xunit;

namespace PropostaService.Application.Tests;

public class CriarPropostaUseCaseTests
{
    [Fact]
    public async Task Executar_DevePersistirNaCamadaDeRepositorio()
    {
        var repo = new Mock<IPropostaRepository>();
        repo.Setup(r => r.AdicionarAsync(It.IsAny<Proposta>())).Returns(Task.CompletedTask);

        var useCase = new CriarPropostaUseCase(repo.Object);

        var p = await useCase.ExecutarAsync("Cliente Teste", 123.45m);

        p.Cliente.Should().Be("Cliente Teste");
        p.Valor.Should().Be(123.45m);
        p.IdStatusProposta.Should().Be((int)StatusPropostaEnum.EmAnalise);

        repo.Verify(r => r.AdicionarAsync(It.Is<Proposta>(x => x.Id == p.Id)), Times.Once);
    }
}
