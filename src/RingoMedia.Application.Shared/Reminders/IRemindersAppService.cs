using System;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using RingoMedia.Reminders.Dtos;
using RingoMedia.Dto;

namespace RingoMedia.Reminders
{
    public interface IRemindersAppService : IApplicationService
    {
        Task<PagedResultDto<ShowReminderList>> GetReminders(GetAllRemindersInput input);

        Task<ShowReminderList> GetReminderById(long id);

        Task<GetReminderForEditOutput> GetReminderForEdit(EntityDto<long> input);

        Task CreateOrEditReminder(CreateOrEditReminderDto input);

        Task DeleteReminder(EntityDto<long> input);

    }
}