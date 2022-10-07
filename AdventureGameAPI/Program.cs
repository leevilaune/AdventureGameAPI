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
    options.UseSqlServer("server=BC-5CD026D1Y5\\CS10DOTNET6; database=AdventureGame; User Id=sa;" + "password=" + password));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

async Task<List<Quest>> GetAllQuests(AdventureGame context) => await context.Quests.ToListAsync();// Päivitää kutsujan pyynnöstä tilatiedot Stats -tauluunapp.MapPut("/superadventure/{id}", async (SuperAdventurecontext, Statstat, int id) =>{// Haetaan pääavaimen (id) persuteella tietueen tietokannastavar dbStat = await context.Stats.FindAsync(id);if (dbStat is null) return Results.NotFound("Ei tilatietoja. :/");// Määritellään päivitettävät tiedotdbStat.CurrentHitPoints = stat.CurrentHitPoints;dbStat.MaxHitPoints = stat.MaxHitPoints;dbStat.Gold = stat.Gold;dbStat.Exp = stat.Exp;// Päivitetään tilatiedotdbStat.CurrentLocationID = stat.CurrentLocationID;


app.UseHttpsRedirection();

app.MapGet("/superadventure", async (AdventureGame context) =>
    await context.Quests.ToListAsync());

app.MapPut("/superadventure", async (AdventureGame context, Quest quest, int id) =>
{
    var dbQuest = await context.Quests.FindAsync(id);
    if (dbQuest is null) return Results.NotFound("no quest");
    dbQuest.Id = quest.Id;
    dbQuest.QuestName = quest.QuestName;
    dbQuest.QuestDesc = quest.QuestDesc;
    dbQuest.QuestReward = quest.QuestReward;
    dbQuest.QuestExp = quest.QuestExp;
    dbQuest.CompletionStatus = quest.CompletionStatus;

    await context.SaveChangesAsync();

    return Results.Ok(await GetAllQuests(context));
});

app.Run();