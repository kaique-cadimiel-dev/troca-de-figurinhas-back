using Microsoft.EntityFrameworkCore;
using DotNetEnv;

var builder = WebApplication.CreateBuilder(args);

// Load .env file
DotNetEnv.Env.Load();

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddControllers();

// Database Configuration
var connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");
builder.Services.AddDbContext<TrocaDeFigurinhas.Data.AppDbContext>(options =>
    options.UseNpgsql(connectionString));

// Register Repositories
builder.Services.AddScoped<TrocaDeFigurinhas.Interfaces.IUserRepository, TrocaDeFigurinhas.Repositories.UserRepository>();
builder.Services.AddScoped<TrocaDeFigurinhas.Interfaces.ITradeSpotRepository, TrocaDeFigurinhas.Repositories.TradeSpotRepository>();
builder.Services.AddScoped<TrocaDeFigurinhas.Interfaces.IReportRepository, TrocaDeFigurinhas.Repositories.ReportRepository>();

// Register Services
builder.Services.AddScoped<TrocaDeFigurinhas.Interfaces.IUserService, TrocaDeFigurinhas.Services.UserService>();
builder.Services.AddScoped<TrocaDeFigurinhas.Interfaces.ITradeSpotService, TrocaDeFigurinhas.Services.TradeSpotService>();
builder.Services.AddScoped<TrocaDeFigurinhas.Interfaces.IReportService, TrocaDeFigurinhas.Services.ReportService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
