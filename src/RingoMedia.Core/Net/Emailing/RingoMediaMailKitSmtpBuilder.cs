﻿using Abp.Localization;
using Abp.MailKit;
using Abp.Net.Mail.Smtp;
using Abp.UI;
using MailKit.Net.Smtp;

namespace RingoMedia.Net.Emailing
{
    public class RingoMediaMailKitSmtpBuilder : DefaultMailKitSmtpBuilder
    {
        private readonly ILocalizationManager _localizationManager;
        private readonly IEmailSettingsChecker _emailSettingsChecker;
        
        public RingoMediaMailKitSmtpBuilder(
            ISmtpEmailSenderConfiguration smtpEmailSenderConfiguration,
            IAbpMailKitConfiguration abpMailKitConfiguration,
            ILocalizationManager localizationManager, 
            IEmailSettingsChecker emailSettingsChecker) : base(smtpEmailSenderConfiguration, abpMailKitConfiguration)
        {
            _localizationManager = localizationManager;
            _emailSettingsChecker = emailSettingsChecker;
        }

        protected override void ConfigureClient(SmtpClient client)
        {
            if (!_emailSettingsChecker.EmailSettingsValid())
            {
                throw new UserFriendlyException(L("SMTPSettingsNotProvidedWarningText"));
            }
            
            client.ServerCertificateValidationCallback = (sender, certificate, chain, errors) => true;
            base.ConfigureClient(client);
        }

        private string L(string name)
        {
            return _localizationManager.GetString(RingoMediaConsts.LocalizationSourceName, name);
        }
    }
}