using Abp;
using Abp.Dependency;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.Threading;
using Abp.Threading.BackgroundWorkers;
using Abp.Threading.Timers;
using RingoMedia.Notifications;
using System;
using System.Threading.Tasks;

namespace RingoMedia.Reminders
{
    public class CheckRemindersAndSendEmails : PeriodicBackgroundWorkerBase, ISingletonDependency
    {
        private const int CheckPeriodAsMilliseconds = 1 * 60 * 5 * 1000; //5 minutes

        private readonly IUnitOfWorkManager _unitOfWorkManager;


        private readonly IAppNotifier _appNotifier;


        protected IRepository<Reminder, long> _reminderRepository { get; private set; }

        public CheckRemindersAndSendEmails(
                   AbpTimer timer,
                   IUnitOfWorkManager unitOfWorkManager,
                   IRepository<Reminder, long> reminderRepository,
                   IAppNotifier appNotifier)
            : base(timer)
        {
            _unitOfWorkManager = unitOfWorkManager;
            _reminderRepository = reminderRepository;


            Timer.Period = CheckPeriodAsMilliseconds;
            Timer.RunOnStart = true;

            LocalizationSourceName = RingoMediaConsts.LocalizationSourceName;
            _appNotifier = appNotifier;
        }


        protected override void DoWork()
        {
            _unitOfWorkManager.WithUnitOfWork(() =>
            {

                // Retrieve the list of reminders that have reached their date/time
                var dueReminders = _reminderRepository.GetAll();



                foreach (var reminder in dueReminders)
                {

                    if (CompareReminderDateTime(reminder.DateTime))
                    {
                        AsyncHelper.RunSync(() => SendReminderEmailAsync(reminder));

                    }

                }
            });
        }

        private async Task SendReminderEmailAsync(Reminder reminder)
        {


            if (reminder.Status != ReminderStatus.SendSuccesfully)
            {
                await _appNotifier.SendReminderEmailAsync(reminder.Title, new UserIdentifier(null, (long)reminder.CreatorUserId));

                reminder.Status = ReminderStatus.SendSuccesfully;

                await _reminderRepository.UpdateAsync(reminder);

                await CurrentUnitOfWork.SaveChangesAsync();

            }



        }

        private bool CompareReminderDateTime(DateTime dateTime)
        {
            // Get the current time
            DateTime currentTime = DateTime.Now;


            // Compare the specific time to the current time
            int comparisonResult = DateTime.Compare(dateTime, currentTime);

            if (comparisonResult < 0)
            {
                // The specific time is earlier than the current time
                // Perform your desired logic here
                return false;

            }
            else if (comparisonResult > 0)
            {
                // The specific time is later than the current time
                // Perform your desired logic here
                return true;

            }
            else
            {
                return true;
            }
        }
    }

}
