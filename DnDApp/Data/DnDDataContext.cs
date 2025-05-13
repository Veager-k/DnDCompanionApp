using DnDApp.Accounts;
using DnDApp.Character;
using Microsoft.EntityFrameworkCore;

namespace DnDApp.Data
{
    public class DndDataContext : DbContext
    {
        public DndDataContext(DbContextOptions<DndDataContext> options) :
            base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseSerialColumns();
        }

        public DbSet<CharacterModel> Characters { get; set; }
    }
}
