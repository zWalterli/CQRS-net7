﻿using System.ComponentModel.DataAnnotations.Schema;

namespace CQRS.Infrastructure.DbModel
{
    [Table("Schedule")]
    public class ScheduleDbModel : BaseDbModel
    {
        public DateTime ScheduleAt { get; set; }
        public Guid ServiceId { get; set; }
        public Guid ProfessionalId { get; set; }
        public string Detail { get; set; } = String.Empty;
    }
}
