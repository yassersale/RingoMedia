using Abp.Application.Services.Dto;
using System;

namespace RingoMedia.Reminders.Dtos
{
    public class GetAllRemindersInput : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }

    }
}