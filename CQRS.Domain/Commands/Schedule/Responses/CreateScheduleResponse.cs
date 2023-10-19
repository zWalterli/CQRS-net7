
using CQRS.Domain.Utils;

namespace CQRS.Domain.Commands.Responses
{
    public class CreateScheduleResponse : BaseResponse
    {
        public Guid Userd { get; set; }
        public Guid ProfessionalId { get; set; }
        public Guid ServiceId { get; set; }
        public DateTime SheduleAt { get; set; }
    }
}
