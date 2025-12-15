using EtteremApi.Models;
using EtteremApi.Services;
using EtteremApi.Services.IServices;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<RestaurantContext>(
        option => 
        { 
            var connectionString = builder.Configuration.GetConnectionString("MySql");
            option.UseMySQL(connectionString);
        }
    );
builder.Services.AddScoped<IRendeles, RendelesService>();
builder.Services.AddScoped<ITermekek, TermekekService>();
builder.Services.AddScoped<IKapcsolo, KapcsoloService>();


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
