using IdentityModel.Client;
using Newtonsoft.Json;
using ProbeTeam.App.Application.Models.Dtos;
using ProbeTeam.App.Domain.Entities;
using ProbeTeam.App.Domain.Services;
using ProbeTeam.App.Infra.DataAccess.Repositories.Players;
using ProbeTeam.Common.Domain.Interfaces.Services;
using ProbeTeam.Common.Infra.Helper.Serializer;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ProbeTeam.App.Application
{
    public class CoachMobileAppService : IAppService
    {
        private string token;

        public IEnumerable<Player> GetAllPlayers()
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", "bearer " + token);
            var result = client.GetAsync("https://probeteam-player-microservice-api.azurewebsites.net/api/players").Result;

            var serializedPlayers = result.Content.ReadAsStringAsync().Result;
            var players = JsonConvert.DeserializeObject<IEnumerable<Player>>(serializedPlayers);

            return players;
        }

        public async Task AddPlayerAsync(Player player)
        {
            //var newPplayer = new Player
            //{
            //    Id = Guid.NewGuid(),
            //    Name = player.Name,
            //    Nickname = player.Nickname,
            //    ShirtNumber = player.ShirtNumber,
            //    IDNumber = player.IDNumber,
            //    Cpf = player.Cpf,
            //    DateOfBirth = player.DateOfBirth
            //};

            var playerService = new PlayerRemoteService(new PlayerMicroserviceRepository(token, new SerializerService()));
            await playerService.CreatePlayerAsync(player);
        }

        public bool SignIn(string username, string password)
        {
            token = GetToken(username, password);
            if (String.IsNullOrEmpty(token))
                return false;
            return true;
        }


        public bool SignUp(UserPasswordDto userPassword)
        {
            var token = GetAdminToken();
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Authorization", "bearer " + token);
            var serializedUserPassword = JsonConvert.SerializeObject(userPassword);
            var httpContent = new StringContent(serializedUserPassword, Encoding.UTF8, "application/json");
            var result = httpClient.PostAsync("https://probeteam-iammicroservice-api.azurewebsites.net/api/UsersAndRoles", httpContent).Result;

            if (!result.IsSuccessStatusCode)
                return false;
            return true;
        }

        private string GetToken(string username, string password)
        {
            var client = new HttpClient();
            var response = client.RequestPasswordTokenAsync(new PasswordTokenRequest
            {
                Address = "https://probeteam-iammicroservice-identity.azurewebsites.net/connect/token",

                ClientId = "ProbeTeamCoachMobileApp_ClientId",
                //ClientSecret = "secret",
                //Scope = "api1",

                UserName = username,
                Password = password
            }).Result;

            return response.AccessToken;
        }

        private object GetAdminToken()
        {
            var client = new HttpClient();
            var response = client.RequestPasswordTokenAsync(new PasswordTokenRequest
            {
                Address = "https://probeteam-iammicroservice-identity.azurewebsites.net/connect/token",

                ClientId = "ProbeTeamCoachMobileApp_ClientId",
                //ClientSecret = "secret",
                //Scope = "api1",

                UserName = "admin",
                Password = ""
            }).Result;

            return response.AccessToken;
        }
    }

}

