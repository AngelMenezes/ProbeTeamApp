using Microsoft.EntityFrameworkCore;
using ProbeTeam.PlayerPunishmentMicroservice.Domain.AggregatesModel.PlayerPunishmentAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProbeTeam.PlayerPunishmentMicroservice.Infra.DataAccess
{
    public class PlayerPunishmentContext : DbContext
    {
        private readonly string dbConnectionString;
        public DbSet<PlayerPunishmentRecord> PlayerPunishments { get; set; }

        public PlayerPunishmentContext()
        {
            this.dbConnectionString = "";
            Database.EnsureCreated();
        }

        public PlayerPunishmentContext(string dbConnectionString)
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
