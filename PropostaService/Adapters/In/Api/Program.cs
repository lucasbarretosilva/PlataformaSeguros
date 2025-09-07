using Microsoft.EntityFrameworkCore;
using PropostaService.Persistence;
using PropostaService.Persistence.Repositories;
using PropostaService.Domain.Ports;
using PropostaService.Application.UseCases;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var conn = builder.Configuration.GetConnectionString("Default") 
           ?? builder.Configuration["ConnectionStrings:Default"];
builder.Services.AddDbContext<PropostasDbContext>(opts => 
    opts.UseSqlServer(conn));

builder.Services.AddScoped<IPropostaRepository, PropostaRepository>();
builder.Services.AddScoped<CriarPropostaUseCase>();
builder.Services.AddScoped<AlterarStatusUseCase>();
builder.Services.AddScoped<ListarPropostasUseCase>();
builder.Services.AddScoped<ObterPropostaUseCase>();

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
