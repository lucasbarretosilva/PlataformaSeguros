using Microsoft.AspNetCore.Mvc;
using PropostaService.Api.Requests.Proposta;
using PropostaService.Api.Response;
using PropostaService.Application.UseCases;

namespace PropostaService.Api.Controllers;

[ApiController]
[Route("propostas")]
public class PropostasController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Criar([FromServices] CriarPropostaUseCase useCase, [FromBody] CriarPropostaRequest req)
    {
        var proposta = await useCase.ExecutarAsync(req.Cliente, req.Valor);
        return CreatedAtAction(nameof(Obter), new { id = proposta.Id }, new PropostaDto(proposta));
    }

    [HttpGet]
    public async Task<IActionResult> Listar([FromServices] ListarPropostasUseCase useCase)
        => Ok((await useCase.ExecutarAsync()).Select(p => new PropostaDto(p)));

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Obter([FromServices] ObterPropostaUseCase useCase, Guid id)
    {
        var proposta = await useCase.ExecutarAsync(id);
        return proposta is null ? NotFound() : Ok(new PropostaDto(proposta));
    }

    [HttpPatch("{id:guid}/status")]
    public async Task<IActionResult> AlterarStatus([FromServices] AlterarStatusUseCase useCase, Guid id, [FromBody] AlterarStatusRequest req)
    {
        var proposta = await useCase.ExecutarAsync(id,req.Status);
        return proposta is null ? NotFound() : Ok(new PropostaDto(proposta!));
    }
}



