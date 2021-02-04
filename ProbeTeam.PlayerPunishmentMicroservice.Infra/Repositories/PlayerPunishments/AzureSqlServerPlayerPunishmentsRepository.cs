using ProbeTeam.Common.Infra.DataAccess.Repositories;
using ProbeTeam.PlayerPunishmentMicroservice.Domain.AggregatesModel.PlayerPunishmentAggregate;
using ProbeTeam.PlayerPunishmentMicroservice.Infra.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProbeTeam.PlayerPunishmentMicroservice.Infra.Repositories.PlayerPunishments
{
    public class AzureSqlServerPlayerPunishmentsRepository : EntityFrameworkRepositoryBase<Guid, PlayerPunishmentRecord>, IPlayerPunishmentRepository
    {
        public AzureSqlServerPlayerPunishmentsRepository()
            :base(new PlayerPunishmentContext(""))
        {
        }
    }
}
