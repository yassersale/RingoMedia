using Abp.Domain.Entities.Auditing;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RingoMedia.Reminders
{
    [Table("Reminders")]
    public class Reminder : FullAuditedEntity<long>
    {

        [Required]
        [StringLength(ReminderConsts.MaxTitleLength)]
        public virtual string Title { get; set; }

        public virtual DateTime DateTime { get; set; }

        public virtual ReminderStatus Status { get; set; }

        public Reminder()
        {

        }

        public Reminder(string title, DateTime dateTime = default, ReminderStatus status = default)
        {



            Title = title;
            DateTime = dateTime;
            Status = status;
        }

    }
}