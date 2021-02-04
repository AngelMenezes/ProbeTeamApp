using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProbeTeam.PlayerMicroservice.Domain.AggregatesModel.PlayerAggregate
{
    public class PlayerService : IPlayerService
    {
        private readonly IPlayerRepository repository;

        public PlayerService(IPlayerRepository repository)
        {
            this.repository = repository;
        }

        public async Task<bool> AddPlayerAsync(Player player)
        {
            player.Id = Guid.NewGuid();
            await repository.CreateAsync(player);
            return await repository.SaveChangesAsync() > 0;
        }

        public IEnumerable<Player> GetAllPlayers()
        {
            return repository.ReadAll();
        }

        public async Task<IEnumerable<Player>> GetAllPlayersAsync()
        {
            return await repository.ReadAllAsync();
        }

        public async Task<bool> UpdatePlayerAsync(Player player)
        {
            repository.Update(player);
            return await repository.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeletePlayerAsync(Guid playerId)
        {
            await repository.DeleteAsync(playerId);
            return await repository.SaveChangesAsync() > 0;
        }

        public async Task<Player> GetPlayerAsync(Guid playerId)
        {
            return await repository.ReadAsync(playerId);
        }

        
    }
}
