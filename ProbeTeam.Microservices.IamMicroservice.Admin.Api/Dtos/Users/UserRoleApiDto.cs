namespace ProbeTeam.Microservices.IamMicroservice.Admin.Api.Dtos.Users
{
    public class UserRoleApiDto<TUserDtoKey, TRoleDtoKey>
    {
        public TUserDtoKey UserId { get; set; }

        public TRoleDtoKey RoleId { get; set; }
    }
}





