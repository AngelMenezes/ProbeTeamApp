using ProbeTeam.Common.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProbeTem.PlayerActivityMicroservice.Domain.AggregatesModel.PlayerActivityAggregate
{
    public interface IPlayerActivityRepository : IRepository<Guid, PlayerActivityRecord>
    {
    }
}
