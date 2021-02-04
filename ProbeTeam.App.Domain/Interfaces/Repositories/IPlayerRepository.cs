using ProbeTeam.App.Domain.Entities;
using ProbeTeam.Common.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProbeTeam.App.Domain.Interfaces.Repositories
{
    public interface IPlayerRepository : IRepository<Guid,Player>
    {
    }
}
