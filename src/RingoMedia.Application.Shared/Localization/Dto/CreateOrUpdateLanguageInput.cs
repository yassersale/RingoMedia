using System.ComponentModel.DataAnnotations;

namespace RingoMedia.Localization.Dto
{
    public class CreateOrUpdateLanguageInput
    {
        [Required]
        public ApplicationLanguageEditDto Language { get; set; }
    }
}