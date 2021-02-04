using IdentityModel.Client;
using Newtonsoft.Json;
using ProbeTeam.App.Application.Models.Dtos;
using ProbeTeam.App.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace ProbeTeam.App.Application
{
    public class ManagerWebAppService
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
        public Player GetPlayer(Guid Player)
        {
            throw new NotImplementedException();
        }
        public bool AddPlayer(Player player)
        {
            throw new NotImplementedException();
        }
        public bool UpdatePlayer(Player player)
        {
            throw new NotImplementedException();
        }
        public bool RemovePlayer(Guid playerId)
        {
            throw new NotImplementedException();
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

        private string GetAdminToken()
        {
            var client = new HttpClient();
            var response = client.RequestPasswordTokenAsync(new PasswordTokenRequest
            {
                Address = "https://probeteam-iammicroservice-identity.azurewebsites.net/connect/token",

                ClientId = "ProbeTeamCoachMobileApp_ClientId",
                //ClientSecret = "secret",
                //Scope = "api1",

                UserName = "",
                Password = ""
            }).Result;

            return response.AccessToken;
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
    }
}

