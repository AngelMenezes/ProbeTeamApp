using ProbeTeam.App.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProbeTeam.App.Domain.Interfaces.Services
{
    interface IPlayerService
    {
        IEnumerable<Player> GetAllPlayers();
        Task CreatePlayerAsync(Player player);
    }
}
