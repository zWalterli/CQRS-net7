using CQRS.Domain.Commands.Responses;
using MediatR;

namespace CQRS.Domain.Commands.Requests
{
    public class CreateScheduleRequest : IRequest<CreateScheduleResponse>
    {
        public Guid UserId { get; set; }
        public Guid ProfessionalId { get; set; }
        public Guid ServiceId { get; set; }
        public DateTime SheduleAt { get; set; }
    }
}
