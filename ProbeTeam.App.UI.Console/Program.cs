using IdentityModel.Client;
using System;
using System.Net.Http;

namespace ProbeTeam.App.UI.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            //http://localhost:65260
            System.Console.WriteLine(GetToken("", ""));
        }

        private static string GetToken(string username, string password)
        {
            var client = new HttpClient();
            var response = client.RequestPasswordTokenAsync(new PasswordTokenRequest
            {
                Address = "https://probeteam-iammicroservice-identity.azurewebsites.net/connect/token",

                ClientId = "PostmanClientId",
                //ClientSecret = "secret",
                //Scope = "api1",

                UserName = username,
                Password = password
            }).Result;

            return response.AccessToken;
        }
    }
}
