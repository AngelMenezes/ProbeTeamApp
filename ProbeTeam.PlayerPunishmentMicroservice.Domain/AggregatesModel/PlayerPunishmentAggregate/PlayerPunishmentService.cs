using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProbeTeam.PlayerPunishmentMicroservice.Domain.AggregatesModel.PlayerPunishmentAggregate
{
    public class PlayerPunishmentService : IPlayerPunishmentService
    {
        private readonly IPlayerPunishmentRepository repository;

        public PlayerPunishmentService(IPlayerPunishmentRepository repository)
        {
            this.repository = repository;
        }

        public async Task<bool> AddPlayerPunishmentAsync(PlayerPunishmentRecord playerPunishmentRecord)
        {
            playerPunishmentRecord.Id = Guid.NewGuid();
            await repository.CreateAsync(playerPunishmentRecord);
            return await repository.SaveChangesAsync() > 0;
        }

        public IEnumerable<PlayerPunishmentRecord> GetAllPlayerPunishments()
        {
            return repository.ReadAll();
        }

        public async Task<IEnumerable<PlayerPunishmentRecord>> GetAllPlayerPunishmentsAsync()
        {
            return await repository.ReadAllAsync();
        }

        public async Task<bool> UpdatePlayerPunishmentAsync(PlayerPunishmentRecord playerPunishmentRecord)
        {
            repository.Update(playerPunishmentRecord);
            return await repository.SaveChangesAsync() > 0;
        }
        public async Task<bool> DeletePlayerPunishmentAsync(Guid playerPunishmentRecordId)
        {
            await repository.DeleteAsync(playerPunishmentRecordId);
            return await repository.SaveChangesAsync() > 0;
        }
        public async Task<PlayerPunishmentRecord> GetPlayerPunishmentAsync(Guid playerPunishmentRecordId)
        {
            return await repository.ReadAsync(playerPunishmentRecordId);
        }
    }
}
