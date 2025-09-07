using System;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using ContratacaoService.Application.UseCases;
using ContratacaoService.Domain.Entities;
using ContratacaoService.Domain.Ports;
using Xunit;

namespace ContratacaoService.Application.Tests;

public class ContratarPropostaUseCaseTests
{
    [Fact]
    public async Task DeveContratar_QuandoStatusAprovada()
    {
        var propostaId = Guid.NewGuid();

        var gateway = new Mock<IPropostaStatusGateway>();
        gateway.Setup(g => g.ObterStatusAsync(propostaId)).ReturnsAsync("Aprovada");

        var repo = new Mock<IContratacaoRepository>();
        repo.Setup(r => r.AdicionarAsync(It.IsAny<Contratacao>())).Returns(Task.CompletedTask);

        var useCase = new ContratarPropostaUseCase(gateway.Object, repo.Object);

        var c = await useCase.ExecutarAsync(propostaId);

        c.Should().NotBeNull();
        c!.PropostaId.Should().Be(propostaId);
        repo.Verify(r => r.AdicionarAsync(It.Is<Contratacao>(x => x.PropostaId == propostaId)), Times.Once);
    }

    [Fact]
    public async Task DeveFalhar_QuandoNaoAprovada()
    {
        var propostaId = Guid.NewGuid();

        var gateway = new Mock<IPropostaStatusGateway>();
        gateway.Setup(g => g.ObterStatusAsync(propostaId)).ReturnsAsync("Rejeitada");

        var repo = new Mock<IContratacaoRepository>();

        var useCase = new ContratarPropostaUseCase(gateway.Object, repo.Object);

        var act = async () => await useCase.ExecutarAsync(propostaId);

        await act.Should().ThrowAsync<InvalidOperationException>()
                 .WithMessage("*não aprovada*");

        repo.Verify(r => r.AdicionarAsync(It.IsAny<Contratacao>()), Times.Never);
    }
}