using SearchScrapAPI.Infrastructure.Interfaces;
using SearchScrapAPI.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddScoped<ISEOSearch, SEOSearch>();
builder.Services.AddScoped<ISEOHistoryRepository, SEOHistoryRepo>();

var app = builder.Build();

app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
