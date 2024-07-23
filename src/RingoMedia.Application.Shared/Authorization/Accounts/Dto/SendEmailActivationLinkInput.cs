using System.ComponentModel.DataAnnotations;

namespace RingoMedia.Authorization.Accounts.Dto
{
    public class SendEmailActivationLinkInput
    {
        [Required]
        public string EmailAddress { get; set; }
    }
}