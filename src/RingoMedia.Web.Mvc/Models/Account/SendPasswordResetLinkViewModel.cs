using System.ComponentModel.DataAnnotations;

namespace RingoMedia.Web.Models.Account
{
    public class SendPasswordResetLinkViewModel
    {
        [Required]
        public string EmailAddress { get; set; }
    }
}