using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProbeTeam.PlayerPunishmentMicroservice.Domain.AggregatesModel.PlayerPunishmentAggregate
{
    public interface IPlayerPunishmentService
    {
        Task<bool> AddPlayerPunishmentAsync(PlayerPunishmentRecord playerPunishmentRecord);
        Task<PlayerPunishmentRecord> GetPlayerPunishmentAsync(Guid playerPunishmentRecordId);
        IEnumerable<PlayerPunishmentRecord> GetAllPlayerPunishments();
        Task<IEnumerable<PlayerPunishmentRecord>> GetAllPlayerPunishmentsAsync();
        Task<bool> UpdatePlayerPunishmentAsync(PlayerPunishmentRecord playerPunishmentRecord);
        Task<bool> DeletePlayerPunishmentAsync(Guid playerPunishmentRecordId);
    }
}
