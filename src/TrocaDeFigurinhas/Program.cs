var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddControllers();

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
