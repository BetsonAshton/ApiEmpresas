using ApiEmpresas.Application.Interfaces;
using ApiEmpresas.Application.Services;
using ApiEmpresas.Domain.Interfaces.Repositories;
using ApiEmpresas.Domain.Interfaces.Services;
using ApiEmpresas.Domain.Services;
using ApiEmpresas.Infra.Data.Repositories;
using ApiEmpresas.Presentation.Configurations;

var builder = WebApplication.CreateBuilder(args);

DependencyInjectionConfiguration.Configure(builder);
CorsConfiguration.AddCorsConfiguration(builder);
AutoMapperConfiguration.Configure(builder);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

CorsConfiguration.UseCorsConfiguration(app);

app.UseSwagger();
app.UseSwaggerUI();


app.UseAuthorization();


app.MapControllers();

app.Run();
