using Microsoft.EntityFrameworkCore;
using ContratacaoService.Persistence;
using ContratacaoService.Persistence.Repositories;
using ContratacaoService.Domain.Ports;
using ContratacaoService.Application.UseCases;
using ContratacaoService.Http;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var conn = builder.Configuration.GetConnectionString("Default") 
           ?? builder.Configuration["ConnectionStrings:Default"];
builder.Services.AddDbContext<ContratacoesDbContext>(opts => 
    opts.UseSqlServer(conn));

builder.Services.AddHttpClient<IPropostaStatusGateway, PropostaStatusHttpGateway>(client => {
    var baseUrl = builder.Configuration["Services:PropostaBaseUrl"] ?? "http://localhost:5001";
    client.BaseAddress = new Uri(baseUrl);
});

builder.Services.AddScoped<IContratacaoRepository, ContratacaoRepository>();
builder.Services.AddScoped<ContratarPropostaUseCase>();
builder.Services.AddScoped<ListarContratacoesUseCase>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();           
}

app.UseHttpsRedirection();

app.MapControllers();

app.MapGet("/", () => Results.Redirect("/swagger"));

app.Run();
