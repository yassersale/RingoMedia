﻿using System.Collections.Generic;
using Abp.Localization;
using RingoMedia.Install.Dto;

namespace RingoMedia.Web.Models.Install
{
    public class InstallViewModel
    {
        public List<ApplicationLanguage> Languages { get; set; }

        public AppSettingsJsonDto AppSettingsJson { get; set; }
    }
}
