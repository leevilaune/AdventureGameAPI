global using Microsoft.EntityFrameworkCore;

namespace AdventureGameAPI
{
    public class AdventureGame : DbContext
    {
        public AdventureGame(DbContextOptions<AdventureGame> options)
            : base(options) { }
        public DbSet<Quest> Quests { get; set; } 
    }
}
