using System.Collections.Generic;
using ProbeTeam.Microservices.IamMicroservice.Admin.Configuration.Identity;

namespace ProbeTeam.Microservices.IamMicroservice.Admin.Configuration.IdentityServer
{
    public class Client : global::IdentityServer4.Models.Client
    {
        public List<Claim> ClientClaims { get; set; } = new List<Claim>();
    }
}






