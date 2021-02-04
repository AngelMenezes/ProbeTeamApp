using ProbeTeam.App.Domain.Entities;
using ProbeTeam.App.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProbeTeam.App.Domain.Services
{
    public class PlayerLocalService
    {
        private readonly IPlayerRepository repository;

        public PlayerLocalService(IPlayerRepository repository)
        {
            this.repository = repository;
        }

        public async Task AddPlayerAsync(Player player)
        {
            player.Id = Guid.NewGuid();
            await repository.CreateAsync(player);
            await repository.SaveChangesAsync();
        }
        public IEnumerable<Player> GetAllPlayers()
        {
            return repository.ReadAll();
        }
        public async Task UpdatePlayerAsync(Player player)
        {
            repository.Update(player);
            await repository.SaveChangesAsync();
        }
        public async Task DeletePlayerAsync(Guid playerId)
        {
            await repository.DeleteAsync(playerId);
            await repository.SaveChangesAsync();
        }
    }
}
