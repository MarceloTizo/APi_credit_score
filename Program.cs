using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using VehicleInsuranceAPI.Models;
using VehicleInsuranceAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Adicionando serviços ao contêiner.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

// Registrando os serviços como Singletons.
builder.Services.AddSingleton<IInsuranceDataService, InsuranceDataService>();
builder.Services.AddSingleton<ICreditScoreService, CreditScoreService>();

var app = builder.Build();

// Configurando o pipeline de requisições HTTP.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

// Definindo apenas a rota necessária
app.MapPost("/insurance/creditscore", (InsuranceData data, ICreditScoreService creditScoreService) =>
{
    var creditScore = creditScoreService.CalculateCreditScore(data);
    return Results.Ok(new { CreditScore = creditScore });
})
.WithName("GetCreditScore")
.WithOpenApi();

// Mapeando os controladores
app.MapControllers();

app.Run();
