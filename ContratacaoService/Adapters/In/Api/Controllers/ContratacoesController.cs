using Microsoft.AspNetCore.Mvc;
using ContratacaoService.Application.UseCases;
using ContratacaoService.Domain.Entities;
using ContratacaoService.Api.Requests;
using ContratacaoService.Api.Responses;

namespace ContratacaoService.Api.Controllers;

[ApiController]
[Route("contratacoes")]
public class ContratacoesController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Contratar([FromServices] ContratarPropostaUseCase useCase, [FromBody] ContratarRequest req)
    {
        try
        {
            var contratacao = await useCase.ExecutarAsync(req.PropostaId);
            return Created($"/contratacoes/{contratacao!.Id}", new ContratacaoDto(contratacao!));
        }
        catch (InvalidOperationException ex)
        {
            return UnprocessableEntity(new { error = ex.Message });
        }
    }

    [HttpGet]
    public async Task<IActionResult> Listar([FromServices] ListarContratacoesUseCase useCase)
        => Ok((await useCase.ExecutarAsync()).Select(c => new ContratacaoDto(c)));

    
    
}
