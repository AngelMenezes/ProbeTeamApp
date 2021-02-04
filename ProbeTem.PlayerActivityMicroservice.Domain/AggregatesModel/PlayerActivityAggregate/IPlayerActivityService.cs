using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProbeTem.PlayerActivityMicroservice.Domain.AggregatesModel.PlayerActivityAggregate
{
    public interface IPlayerActivityService
    {
        Task<bool> AddPlayerActivityAsync(PlayerActivityRecord playerActivityRecord);
        Task<PlayerActivityRecord> GetPlayerActivityAsync(Guid playerActivityRecordId);
        IEnumerable<PlayerActivityRecord> GetAllPlayerActivities();
        Task<IEnumerable<PlayerActivityRecord>> GetAllPlayerActivitiesAsync();
        Task<bool> UpdatePlayerActivityAsync(PlayerActivityRecord playerActivityRecord);
        Task<bool> DeletePlayerActivityAsync(Guid playerActivityRecordId);
    }
}
