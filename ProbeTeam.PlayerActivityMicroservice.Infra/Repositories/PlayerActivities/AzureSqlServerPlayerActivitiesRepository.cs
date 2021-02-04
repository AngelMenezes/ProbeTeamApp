using ProbeTeam.Common.Infra.DataAccess.Repositories;
using ProbeTeam.PlayerActivityMicroservice.Infra.DataAccess;
using ProbeTem.PlayerActivityMicroservice.Domain.AggregatesModel.PlayerActivityAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProbeTeam.PlayerActivityMicroservice.Infra.Repositories.PlayerActivities
{
    public class AzureSqlServerPlayerActivitiesRepository : EntityFrameworkRepositoryBase<Guid, PlayerActivityRecord>, IPlayerActivityRepository
    {
        public AzureSqlServerPlayerActivitiesRepository()
            :base(new PlayerActivityContext("")) 
        {
        }
    }
}
