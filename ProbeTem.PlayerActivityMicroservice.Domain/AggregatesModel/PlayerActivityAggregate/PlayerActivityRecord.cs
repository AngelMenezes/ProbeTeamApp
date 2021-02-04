using ProbeTeam.Common.Domain.Entities;
using ProbeTeam.PlayerMicroservice.Domain.AggregatesModel.PlayerAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProbeTem.PlayerActivityMicroservice.Domain.AggregatesModel.PlayerActivityAggregate
{
    public class PlayerActivityRecord : EntityBase<Guid>
    {
        public Player Player { get; set; }
        public PlayerActivity PlayerActivity { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
