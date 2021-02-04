using Microsoft.EntityFrameworkCore;
using ProbeTeam.App.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProbeTeam.App.Infra.DataAccess.Contexts
{
    public class ProbeTeamLocalContext : DbContext
    {
        private readonly string dbConnectionString;
        public DbSet<Player> Players { get; set; }

        public ProbeTeamLocalContext()
        {

        }

        public ProbeTeamLocalContext(string dbConnectionString)
        {
            this.dbConnectionString = dbConnectionString;
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);            
            optionsBuilder.UseSqlite(dbConnectionString);
        }
    }
}
