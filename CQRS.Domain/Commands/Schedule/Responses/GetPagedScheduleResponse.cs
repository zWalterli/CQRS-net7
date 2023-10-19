using CQRS.Domain.Base;

namespace CQRS.Domain.Commands.Schedule.Responses
{
    public class GetPagedScheduleResponse : BaseResponse
    {
        public DateTime ScheduleAt { get; set; }
        public Guid ServiceId { get; set; }
        public Guid ProfessionalId { get; set; }
        public string Detail { get; set; } = String.Empty;
    }
}
