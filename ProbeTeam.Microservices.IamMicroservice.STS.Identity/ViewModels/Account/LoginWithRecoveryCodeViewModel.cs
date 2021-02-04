using System.ComponentModel.DataAnnotations;

namespace ProbeTeam.Microservices.IamMicroservice.STS.Identity.ViewModels.Account
{
    public class LoginWithRecoveryCodeViewModel
    {
        [Required]
        [DataType(DataType.Text)]
        public string RecoveryCode { get; set; }

        public string ReturnUrl { get; set; }
    }
}






