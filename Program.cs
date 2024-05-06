using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using VehicleInsuranceAPI.Models;
using VehicleInsuranceAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Adicionando serviços ao contêiner.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Registrando os serviços como Singletons.
builder.Services.AddSingleton<IInsuranceDataService, InsuranceDataService>();
builder.Services.AddSingleton<ICreditScoreService, CreditScoreService>();

 builder.Services.AddControllers();

var app = builder.Build();

// Configure o pipeline de requisições HTTP.


    app.UseSwagger();
    app.UseSwaggerUI();


app.UseHttpsRedirection();

// Definindo apenas a rota necessária
app.MapPost("/insurance/creditscore", (InsuranceData data, ICreditScoreService creditScoreService) =>
{
    var creditScore = creditScoreService.CalculateCreditScore(data);
    return Results.Ok(new { CreditScore = creditScore });
})
.WithName("GetCreditScore")
.WithOpenApi();

app.Run();
