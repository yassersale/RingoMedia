using RingoMedia.Reminders;

using System;

using Abp.Application.Services.Dto;

namespace RingoMedia.Reminders.Dtos
{
    public class ReminderListDto : EntityDto<long>
    {

        public string Title { get; set; }

        public DateTime DateTime { get; set; }

        public ReminderStatus Status { get; set; }

        public ReminderListDto()
        {

        }

    }
}