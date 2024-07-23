using RingoMedia.Reminders;
using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using Abp.Linq.Extensions;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using RingoMedia.Reminders.Dtos;
using RingoMedia.Dto;
using Abp.Application.Services.Dto;
using RingoMedia.Authorization;
using Abp.Extensions;
using Abp.Authorization;
using Microsoft.EntityFrameworkCore;
using Abp.UI;
using RingoMedia.Storage;

namespace RingoMedia.Reminders
{
    [AbpAuthorize(AppPermissions.Pages_Reminders)]
    public class RemindersAppService : RingoMediaAppServiceBase, IRemindersAppService
    {

        private readonly IRepository<Reminder, long> _reminderRepository;

        public RemindersAppService(
        IRepository<Reminder, long> reminderRepository
        )
        {
            _reminderRepository = reminderRepository;

        }

        // private void GetAll(GetAllTest2sInput input){}

        public async Task<PagedResultDto<ShowReminderList>> GetReminders(GetAllRemindersInput input)
        {

            var filteredReminders = _reminderRepository.GetAll()

                            .WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false || e.Title.Contains(input.Filter));

            var pagedAndFilteredReminders = filteredReminders
                .OrderBy(input.Sorting ?? "id asc")
                .PageBy(input);

            var reminders = from reminder in pagedAndFilteredReminders
                            select new
                            {
                                reminder
                            };

            var totalCount = await filteredReminders.CountAsync();

            var dbList = await reminders.ToListAsync();
            var results = dbList.Select(u =>
                {
                    var reminder = ObjectMapper.Map<ShowReminderList>(u.reminder);

                    return reminder;

                }).ToList();

            return new PagedResultDto<ShowReminderList>(
                totalCount,
                results
            );

        }
        public async Task<ShowReminderList> GetReminderById(long id)
        {
            var reminder = await _reminderRepository.GetAll()
            .Where(e => e.Id == id).FirstOrDefaultAsync();

            var output = ObjectMapper.Map<ShowReminderList>(reminder);

            return output;
        }

        public async Task<ReminderReport> GetReminderForReport(long id)
        {

            var reminder = await _reminderRepository.GetAll()

                    .Where(e => e.Id == id).FirstOrDefaultAsync();

            var output = ObjectMapper.Map<ReminderReport>(reminder);

            return output;
        }

        [AbpAuthorize(AppPermissions.Pages_Reminders_Edit)]
        public async Task<GetReminderForEditOutput> GetReminderForEdit(EntityDto<long> input)
        {
            var reminder = await _reminderRepository.FirstOrDefaultAsync(input.Id);

            var output = new GetReminderForEditOutput { Reminder = ObjectMapper.Map<CreateOrEditReminderDto>(reminder) };

            return output;
        }

        public async Task CreateOrEditReminder(CreateOrEditReminderDto input)
        {
            if (input.Id == null || input.Id == 0)
            {
                await Create(input);

            }
            else
            {
                await Update(input);
            }

        }

        [AbpAuthorize(AppPermissions.Pages_Reminders_Create)]
        protected virtual async Task Create(CreateOrEditReminderDto input)
        {
            var reminder = ObjectMapper.Map<Reminder>(input);

            await _reminderRepository.InsertAndGetIdAsync(reminder);

        }

        [AbpAuthorize(AppPermissions.Pages_Reminders_Edit)]
        protected virtual async Task Update(CreateOrEditReminderDto input)
        {
            var reminder = await _reminderRepository.GetAll()
                        .Where(e => e.Id == (long)input.Id).FirstOrDefaultAsync();

            ObjectMapper.Map(ObjectMapper.Map<EditReminderDto>(input), reminder);

        }

        [AbpAuthorize(AppPermissions.Pages_Reminders_Delete)]
        public async Task DeleteReminder(EntityDto<long> input)
        {
            await _reminderRepository.DeleteAsync(input.Id);
        }

    }
}