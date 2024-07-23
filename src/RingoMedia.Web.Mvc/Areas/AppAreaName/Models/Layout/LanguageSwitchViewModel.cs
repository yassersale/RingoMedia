﻿using System.Collections.Generic;
using Abp.Localization;

namespace RingoMedia.Web.Areas.AppAreaName.Models.Layout
{
    public class LanguageSwitchViewModel
    {
        public IReadOnlyList<LanguageInfo> Languages { get; set; }

        public LanguageInfo CurrentLanguage { get; set; }
        
        public string CssClass { get; set; }
        
        public string IconClass { get; set; }
    }
}
