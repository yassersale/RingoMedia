﻿using System.ComponentModel.DataAnnotations;

namespace RingoMedia.Authorization.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}
