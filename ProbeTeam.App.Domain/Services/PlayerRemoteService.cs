using ProbeTeam.App.Domain.Entities;
using ProbeTeam.App.Domain.Interfaces.Repositories;
using ProbeTeam.App.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProbeTeam.App.Domain.Services
{
    public class PlayerRemoteService : IPlayerService 
    {
        private IPlayerRepository playerRepository;

        public PlayerRemoteService(IPlayerRepository playerRepository)
        {
            this.playerRepository = playerRepository;
        }

        public async Task CreatePlayerAsync(Player player)
        {
            await playerRepository.CreateAsync(player);
        }

        public IEnumerable<Player> GetAllPlayers()
        {
            throw new NotImplementedException();
        }
    }
}
