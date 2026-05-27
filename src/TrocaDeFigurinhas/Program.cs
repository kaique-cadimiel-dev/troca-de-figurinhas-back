using Microsoft.EntityFrameworkCore;
using DotNetEnv;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Load .env file - TraversePath helps find the .env file in parent directories
DotNetEnv.Env.TraversePath().Load();

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddControllers();

// JWT Authentication Configuration
var jwtSecret = Environment.GetEnvironmentVariable("JWT_SECRET");
if (string.IsNullOrEmpty(jwtSecret))
{
    throw new InvalidOperationException("A variável de ambiente 'JWT_SECRET' não foi encontrada. Verifique o arquivo .env.");
}

var key = Encoding.ASCII.GetBytes(jwtSecret);
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

builder.Services.AddAuthorization();

// Database Configuration
if (builder.Environment.EnvironmentName != "Testing")
{
    var connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");
    
    if (string.IsNullOrEmpty(connectionString))
    {
        throw new InvalidOperationException("A variável de ambiente 'DB_CONNECTION_STRING' não foi encontrada. Verifique o arquivo .env.");
    }
    
    builder.Services.AddDbContext<TrocaDeFigurinhas.Data.AppDbContext>(options =>
        options.UseNpgsql(connectionString));
}

// Register Repositories
builder.Services.AddScoped<TrocaDeFigurinhas.Interfaces.IUserRepository, TrocaDeFigurinhas.Repositories.UserRepository>();
builder.Services.AddScoped<TrocaDeFigurinhas.Interfaces.ITradeSpotRepository, TrocaDeFigurinhas.Repositories.TradeSpotRepository>();
builder.Services.AddScoped<TrocaDeFigurinhas.Interfaces.IReportRepository, TrocaDeFigurinhas.Repositories.ReportRepository>();

// Register Services
builder.Services.AddScoped<TrocaDeFigurinhas.Interfaces.IAuthService, TrocaDeFigurinhas.Services.AuthService>();
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

app.UseAuthentication();
app.UseAuthorization();

app.MapGet("/", () => "API Rodando");

app.MapControllers();

app.Run();
