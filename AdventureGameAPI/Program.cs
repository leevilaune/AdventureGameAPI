using AdventureGameAPI;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

Console.Write("Input password: ");
string password = Console.ReadLine();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AdventureGame>(options =>
    options.UseSqlServer("server=BC-5CD026D1Y5\\CS10DOTNET6; database=AdventureGame; User Id=sa;" + "password =" + password));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/superadventure", async (AdventureGame context) =>
    await context.Quests.ToListAsync());

app.Run();