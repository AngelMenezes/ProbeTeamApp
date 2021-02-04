using ProbeTeam.Common.Domain.Entities;
using ProbeTeam.PlayerMicroservice.Domain.AggregatesModel.PlayerAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProbeTeam.PlayerPunishmentMicroservice.Domain.AggregatesModel.PlayerPunishmentAggregate
{
    public class PlayerPunishmentRecord : EntityBase<Guid>
    {
        public Player Player { get; set; }
        public PlayerPunishment PlayerPunishment { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
