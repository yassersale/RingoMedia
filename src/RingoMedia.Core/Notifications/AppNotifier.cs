using Abp;
using Abp.Localization;
using Abp.Notifications;
using RingoMedia.Authorization.Users;
using RingoMedia.MultiTenancy;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RingoMedia.Notifications
{
    public class AppNotifier : RingoMediaDomainServiceBase, IAppNotifier
    {
        private readonly INotificationPublisher _notificationPublisher;

        private readonly INotificationConfiguration _notificationConfiguration;


        public AppNotifier(INotificationPublisher notificationPublisher, INotificationConfiguration notificationConfiguration)
        {
            _notificationPublisher = notificationPublisher;
            _notificationConfiguration = notificationConfiguration;
        }

        public async Task WelcomeToTheApplicationAsync(User user)
        {
            await _notificationPublisher.PublishAsync(
                AppNotificationNames.WelcomeToTheApplication,
                new MessageNotificationData(L("WelcomeToTheApplicationNotificationMessage")),
                severity: NotificationSeverity.Success,
                userIds: new[] { user.ToUserIdentifier() }
            );
        }

        public async Task NewUserRegisteredAsync(User user)
        {
            var notificationData = new LocalizableMessageNotificationData(
                new LocalizableString(
                    "NewUserRegisteredNotificationMessage",
                    RingoMediaConsts.LocalizationSourceName
                )
            );

            notificationData["userName"] = user.UserName;
            notificationData["emailAddress"] = user.EmailAddress;

            await _notificationPublisher.PublishAsync(AppNotificationNames.NewUserRegistered, notificationData,
                tenantIds: new[] { user.TenantId });
        }

        public async Task NewTenantRegisteredAsync(Tenant tenant)
        {
            var notificationData = new LocalizableMessageNotificationData(
                new LocalizableString(
                    "NewTenantRegisteredNotificationMessage",
                    RingoMediaConsts.LocalizationSourceName
                )
            );

            notificationData["tenancyName"] = tenant.TenancyName;
            await _notificationPublisher.PublishAsync(AppNotificationNames.NewTenantRegistered, notificationData);
        }

        public async Task GdprDataPrepared(UserIdentifier user, Guid binaryObjectId)
        {
            var notificationData = new LocalizableMessageNotificationData(
                new LocalizableString(
                    "GdprDataPreparedNotificationMessage",
                    RingoMediaConsts.LocalizationSourceName
                )
            );

            notificationData["binaryObjectId"] = binaryObjectId;

            await _notificationPublisher.PublishAsync(AppNotificationNames.GdprDataPrepared, notificationData,
                userIds: new[] { user });
        }

        //This is for test purposes
        public async Task SendMessageAsync(UserIdentifier user, string message,
            NotificationSeverity severity = NotificationSeverity.Info)
        {
            await _notificationPublisher.PublishAsync(
                AppNotificationNames.SimpleMessage,
                new MessageNotificationData(message),
                severity: severity,
                userIds: new[] { user }
            );
        }

        public Task SendMessageAsync(UserIdentifier user, LocalizableString localizableMessage,
            IDictionary<string, object> localizableMessageData = null,
            NotificationSeverity severity = NotificationSeverity.Info)
        {
            return SendNotificationAsync(AppNotificationNames.SimpleMessage, user, localizableMessage,
                localizableMessageData, severity);
        }

        protected async Task SendNotificationAsync(string notificationName, UserIdentifier user,
            LocalizableString localizableMessage, IDictionary<string, object> localizableMessageData = null,
            NotificationSeverity severity = NotificationSeverity.Info)
        {
            var notificationData = new LocalizableMessageNotificationData(localizableMessage);
            if (localizableMessageData != null)
            {
                foreach (var pair in localizableMessageData)
                {
                    notificationData[pair.Key] = pair.Value;
                }
            }

            await _notificationPublisher.PublishAsync(notificationName, notificationData, severity: severity,
                userIds: new[] { user });
        }

        public Task TenantsMovedToEdition(UserIdentifier user, string sourceEditionName, string targetEditionName)
        {
            return SendNotificationAsync(AppNotificationNames.TenantsMovedToEdition, user,
                new LocalizableString(
                    "TenantsMovedToEditionNotificationMessage",
                    RingoMediaConsts.LocalizationSourceName
                ),
                new Dictionary<string, object>
                {
                    {"sourceEditionName", sourceEditionName},
                    {"targetEditionName", targetEditionName}
                });
        }

        public Task<TResult> TenantsMovedToEdition<TResult>(UserIdentifier argsUser, int sourceEditionId,
            int targetEditionId)
        {
            throw new NotImplementedException();
        }

        public Task SomeUsersCouldntBeImported(UserIdentifier user, string fileToken, string fileType, string fileName)
        {
            return SendNotificationAsync(AppNotificationNames.DownloadInvalidImportUsers, user,
                new LocalizableString(
                    "ClickToSeeInvalidUsers",
                    RingoMediaConsts.LocalizationSourceName
                ),
                new Dictionary<string, object>
                {
                    { "fileToken", fileToken },
                    { "fileType", fileType },
                    { "fileName", fileName }
                });
        }

        public async Task SendMassNotificationAsync(string message, UserIdentifier[] userIds = null,
             NotificationSeverity severity = NotificationSeverity.Info,
            Type[] targetNotifiers = null
        )
        {
            await _notificationPublisher.PublishAsync(
                AppNotificationNames.MassNotification,
                new MessageNotificationData(message),
                severity: severity,
                userIds: userIds,
                targetNotifiers: targetNotifiers
            );
        }

        public async Task SendReminderEmailAsync(string message, UserIdentifier user = null)
        {
            var userIds = new List<UserIdentifier>();

            var targetNotifiersInput = new List<string>();

            targetNotifiersInput.Add(AppNotificationNames.EmailTarget);

            userIds.Add(user);


            var targetNotifiersType = new List<Type>();

            foreach (var notifier in _notificationConfiguration.Notifiers)
            {
                if (targetNotifiersInput.Contains(notifier.FullName))
                {
                    targetNotifiersType.Add(notifier);
                }
            }


            await _notificationPublisher.PublishAsync(
                AppNotificationNames.MassNotification,
                new MessageNotificationData(message),
                severity: NotificationSeverity.Info,
                userIds: userIds.ToArray(),
                targetNotifiers: targetNotifiersType.ToArray()
            );

        }

    }



}
