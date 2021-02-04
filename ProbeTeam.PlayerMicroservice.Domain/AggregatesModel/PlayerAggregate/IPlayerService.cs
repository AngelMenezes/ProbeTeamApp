using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProbeTeam.PlayerMicroservice.Domain.AggregatesModel.PlayerAggregate
{
    public interface IPlayerService
    {
        Task<bool> AddPlayerAsync(Player player);
        Task<Player> GetPlayerAsync(Guid playerId);
        IEnumerable<Player> GetAllPlayers();
        Task<IEnumerable<Player>> GetAllPlayersAsync();
        Task<bool> UpdatePlayerAsync(Player player);
        Task<bool> DeletePlayerAsync(Guid playerId);
    }
}
