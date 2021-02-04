using ProbeTeam.Common.Infra.DataAccess.Repositories;
using ProbeTeam.PlayerMicroservice.Domain.AggregatesModel.PlayerAggregate;
using ProbeTeam.PlayerMicroservice.Infra.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProbeTeam.PlayerMicroservice.Infra.Repositories.Players
{
    public class AzureSqlServerPlayersRepository : EntityFrameworkRepositoryBase<Guid, Player>, IPlayerRepository
    {
        public AzureSqlServerPlayersRepository()
            : base(new PlayerContext("Server=tcp:probeteam-player-microservice-db-server.database.windows.net,1433;Initial Catalog=ProbeTeam-Player-Microservice-db;Persist Security Info=False;User ID= ;Password= ;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
        {
        }
    }
}
