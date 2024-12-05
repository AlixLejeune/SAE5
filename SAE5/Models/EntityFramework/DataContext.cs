using Microsoft.EntityFrameworkCore;

namespace SAE501_Blazor_API.Models.EntityFramework
{
    public class DataContext : DbContext
    {
        public DataContext()
        {
        }

        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Building> buildings { get; set; } = null!;
        public virtual DbSet<Door> doors { get; set; } = null!;
        public virtual DbSet<Furniture> furnitures { get; set; } = null!;
        public virtual DbSet<FurnitureType> furnitureTypes { get; set; } = null!;
        public virtual DbSet<Room> rooms { get; set; } = null!;
        public virtual DbSet<RoomType> roomTypes { get; set; } = null!;
        public virtual DbSet<Sensor> sensors { get; set; } = null!;
        public virtual DbSet<Wall> walls { get; set; } = null!;
        public virtual DbSet<Window> windows { get; set; } = null!;


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("SAE_DB_Local");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Building>();
            modelBuilder.Entity<Door>();
            modelBuilder.Entity<Furniture>();
            modelBuilder.Entity<FurnitureType>();
            modelBuilder.Entity<Room>();
            modelBuilder.Entity<RoomType>();
            modelBuilder.Entity<Sensor>();
            modelBuilder.Entity<Wall>();
            modelBuilder.Entity<Window>();
        }
    }
}
