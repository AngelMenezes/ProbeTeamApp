using ProbeTeam.Microservices.IamMicroservice.Admin.Api.ExceptionHandling;

namespace ProbeTeam.Microservices.IamMicroservice.Admin.Api.Resources
{
    public class ApiErrorResources : IApiErrorResources
    {
        public virtual ApiError CannotSetId()
        {
            return new ApiError
            {
                Code = nameof(CannotSetId),
                Description = ApiErrorResource.CannotSetId
            };
        }
    }
}





