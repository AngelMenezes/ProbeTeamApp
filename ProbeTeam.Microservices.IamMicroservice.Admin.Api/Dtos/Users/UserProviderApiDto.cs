namespace ProbeTeam.Microservices.IamMicroservice.Admin.Api.Dtos.Users
{
    public class UserProviderApiDto<TUserDtoKey>
    {
        public TUserDtoKey UserId { get; set; }

        public string UserName { get; set; }

        public string ProviderKey { get; set; }

        public string LoginProvider { get; set; }

        public string ProviderDisplayName { get; set; }
    }
}





