using System.Collections.Generic;

namespace ProbeTeam.Microservices.IamMicroservice.Admin.Configuration.Identity
{
    public class Role
    {
        public string Name { get; set; }
        public List<Claim> Claims { get; set; } = new List<Claim>();
    }
}






