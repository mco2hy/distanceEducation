using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

namespace WebApplication2
{
    public class DataContext : DbContext
    {
        public DataContext (DbContextOptions<DataContext> contextOptions) : base(contextOptions)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Color>().HasData(new Color()
            {
                Id = 1,
                Name = "Siyah"
            });

            modelBuilder.Entity<Color>().HasData(new Color()
            {
                Id = 2,
                Name = "Beyaz"
            });

            modelBuilder.Entity<Color>().HasData(new Color()
            {
                Id = 3,
                Name = "Kırmızı"
            });

            modelBuilder.Entity<Color>().HasData(new Color()
            {
                Id = 4,
                Name = "Sarı"
            });

            modelBuilder.Entity<Color>().HasData(new Color()
            {
                Id = 5,
                Name = "Lacivert"
            });
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Club> Clubs { get; set; }
        public DbSet<ClubColor> ClubColors { get; set; }
    }
}
