using ProbeTeam.App.Application.Models.Dtos;
using ProbeTeam.App.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProbeTeam.App.Application
{
    public interface IAppService
    {
        Task AddPlayerAsync(Player player);
        bool SignIn(string username, string password);
        bool SignUp(UserPasswordDto userPassword);
        IEnumerable<Player> GetAllPlayers();
    }
}
