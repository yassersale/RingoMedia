using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace RingoMedia.Reminders.Dtos
{
    public class GetReminderForReportOutput
    {
        public CreateOrEditReminderDto Reminder { get; set; }

    }
}