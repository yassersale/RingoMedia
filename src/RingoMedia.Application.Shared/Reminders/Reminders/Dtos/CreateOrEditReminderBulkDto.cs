using RingoMedia.Reminders;

using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace RingoMedia.Reminders.Dtos
{
    public class CreateOrEditReminderBulkDto : EntityDto<long?>
    {

        [Required]
        [StringLength(ReminderConsts.MaxTitleLength)]
        public string Title { get; set; }

        public DateTime DateTime { get; set; }

        public CreateOrEditReminderBulkDto()
        {

        }

    }
}