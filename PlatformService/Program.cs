using Microsoft.EntityFrameworkCore;
using PlatformService.Data;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

string? connectionString = builder.Configuration.GetConnectionString("Default");
if(connectionString == null)
{
    Console.WriteLine("Failed to read connection string");
    return;
}
builder.Services.AddDbContext<AppDbContext>(
    (DbContextOptionsBuilder options) => options.UseSqlServer(connectionString)
    );

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
