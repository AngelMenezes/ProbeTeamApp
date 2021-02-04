using ProbeTeam.Common.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProbeTeam.PlayerPunishmentMicroservice.Domain.AggregatesModel.PlayerPunishmentAggregate
{
    public interface IPlayerPunishmentRepository : IRepository<Guid, PlayerPunishmentRecord>
    {
    }
}
