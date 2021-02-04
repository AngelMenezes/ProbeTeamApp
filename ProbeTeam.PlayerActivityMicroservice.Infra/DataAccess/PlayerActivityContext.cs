using Microsoft.EntityFrameworkCore;
using ProbeTem.PlayerActivityMicroservice.Domain.AggregatesModel.PlayerActivityAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProbeTeam.PlayerActivityMicroservice.Infra.DataAccess
{
    public class PlayerActivityContext : DbContext
    {
        private readonly string dbConnectionString;
        public DbSet<PlayerActivityRecord> PlayerActivities { get; set; }

        public PlayerActivityContext()
        {
            this.dbConnectionString = "";
            Database.EnsureCreated();
        }

        public PlayerActivityContext(string dbConnectionString)
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
