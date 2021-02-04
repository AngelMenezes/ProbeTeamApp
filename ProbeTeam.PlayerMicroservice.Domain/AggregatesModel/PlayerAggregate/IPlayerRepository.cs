using ProbeTeam.Common.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProbeTeam.PlayerMicroservice.Domain.AggregatesModel.PlayerAggregate
{
    public interface IPlayerRepository : IRepository<Guid,Player>
    {
    }
}
