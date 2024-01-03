using Maui.CommandPattern.EntityLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace Maui.CommandPattern.EntityLibrary
{
    public class CommandPatternContext : DbContext
    {
        public CommandPatternContext()
        {
            
        }

        public CommandPatternContext(DbContextOptions<CommandPatternContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlite();

        DbSet<MtgSet> MtgSets => Set<MtgSet>();
        DbSet<MtgCard> MtgCards => Set<MtgCard>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<MtgSet>().HasData(
                new MtgSet { Id = 1, Description = "Alpha", IsActive = true, Name = "Alpha", ReleaseYear = 1993 },
                new MtgSet { Id = 2, Description = "Beta", IsActive = true, Name = "Beta", ReleaseYear = 1993 }
            );

            modelBuilder.Entity<MtgCard>().HasData(
                new MtgCard { Id = 1, Color = "None", Description = "Black Lotus", IsActive = true, MtgSetId = 1, Name = "Black Lotus", Type = "Artifact" },
                new MtgCard { Id = 2, Color = "None", Description = "Black Lotus", IsActive = true, MtgSetId = 2, Name = "Black Lotus", Type = "Artifact" }
            );
        }
    }
}
