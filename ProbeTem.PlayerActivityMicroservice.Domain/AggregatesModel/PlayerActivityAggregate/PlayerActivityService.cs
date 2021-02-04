using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProbeTem.PlayerActivityMicroservice.Domain.AggregatesModel.PlayerActivityAggregate
{
    public class PlayerActivityService : IPlayerActivityService
    {
        private readonly IPlayerActivityRepository repository;

        public PlayerActivityService(IPlayerActivityRepository repository)
        {
            this.repository = repository;
        }

        public async Task<bool> AddPlayerActivityAsync(PlayerActivityRecord playerActivityRecord)
        {
            playerActivityRecord.Id = Guid.NewGuid();
            await repository.CreateAsync(playerActivityRecord);
            return await repository.SaveChangesAsync() > 0;
        }

        public IEnumerable<PlayerActivityRecord> GetAllPlayerActivities()
        {
            return repository.ReadAll();
        }

        public async Task<IEnumerable<PlayerActivityRecord>> GetAllPlayerActivitiesAsync()
        {
            return await repository.ReadAllAsync();
        }

        public async Task<bool> UpdatePlayerActivityAsync(PlayerActivityRecord playerActivityRecord)
        {
            repository.Update(playerActivityRecord);
            return await repository.SaveChangesAsync() > 0;
        }
        public async Task<bool> DeletePlayerActivityAsync(Guid playerActivityRecordId)
        {
            await repository.DeleteAsync(playerActivityRecordId);
            return await repository.SaveChangesAsync() > 0;
        }

        public async Task<PlayerActivityRecord> GetPlayerActivityAsync(Guid playerActivityRecordId)
        {
            return await repository.ReadAsync(playerActivityRecordId);
        }
    }
}
