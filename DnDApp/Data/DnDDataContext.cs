using DnDApp.Character;
using Microsoft.EntityFrameworkCore;

namespace DnDApp.Data
{
    public class DnDDataContext : DbContext
    {
        public DnDDataContext(DbContextOptions<DnDDataContext> options): 
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
