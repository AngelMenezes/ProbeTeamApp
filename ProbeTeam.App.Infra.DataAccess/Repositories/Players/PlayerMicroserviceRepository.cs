using ProbeTeam.App.Domain.Entities;
using ProbeTeam.App.Domain.Interfaces.Repositories;
using ProbeTeam.Common.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ProbeTeam.App.Infra.DataAccess.Repositories.Players
{
    public class PlayerMicroserviceRepository : IPlayerRepository
    {
        private readonly string token;
        private readonly ISerializerService serializerService;

        public PlayerMicroserviceRepository(string token, ISerializerService serializerService)
        {
            this.token = token;
            this.serializerService = serializerService;
        }

        public async Task CreateAsync(Player entity)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", "bearer " + token);
            var playerSerialized = serializerService.Serialize(entity);
            var httpContent = new StringContent(playerSerialized, Encoding.UTF8, "application/json");
            await client.PostAsync("https://probeteam-player-microservice-api.azurewebsites.net/api/players", httpContent);
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Player> ReadAll()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Player>> ReadAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Player> ReadAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<int> SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        public void Update(Player entity)
        {
            throw new NotImplementedException();
        }
    }
}
