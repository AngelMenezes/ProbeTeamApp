using Microsoft.EntityFrameworkCore;
using ProbeTeam.PlayerMicroservice.Domain.AggregatesModel.PlayerAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProbeTeam.PlayerMicroservice.Infra.DataAccess
{
    public class PlayerContext : DbContext
    {
        private readonly string dbConnectionString;
        public DbSet<Player> Players { get; set; }

        public PlayerContext()
        {
            this.dbConnectionString = "Server=tcp:probeteam-player-microservice-db-server.database.windows.net,1433;Initial Catalog=ProbeTeam-Player-Microservice-db;Persist Security Info=False;User ID= ;Password= ;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            Database.EnsureCreated();
        }

        public PlayerContext(string dbConnectionString)
        {
            this.dbConnectionString = dbConnectionString;
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(dbConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
