using Abp.Application.Services.Dto;
using System;
using System.ComponentModel.DataAnnotations;

namespace RingoMedia.Reminders.Dtos
{
    public class GetRemindersInput : PagedAndSortedResultRequestDto
    {
        [Range(1, long.MaxValue)]
        public long Id { get; set; }

        public string Filter { get; set; }

    }
}