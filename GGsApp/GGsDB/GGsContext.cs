using Microsoft.EntityFrameworkCore;
using GGsDB.Models;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace GGsDB
{
    public class GGsContext : DbContext
    {
        public DbSet<Customer> Customers {get; set;}
        public DbSet<Manager> Managers {get; set;}
        public DbSet<Inventory> Inventories {get; set;}
        public DbSet<Location> Locations {get; set;}
        public DbSet<Order> Orders {get; set;}
        public DbSet<GameConsole> GameConsoles {get; set;}
        public DbSet<VideoGame> VideoGames {get; set;}

        public GGsContext()
        {

        }
        public GGsContext(DbContextOptions<GGsContext> options)
            : base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

                var connectionString = configuration.GetConnectionString("GGsDB");
                optionsBuilder.UseNpgsql(connectionString);
            }
        }
    }
}