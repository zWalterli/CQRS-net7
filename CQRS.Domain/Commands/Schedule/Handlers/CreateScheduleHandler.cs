using CQRS.Domain.Commands.Requests;
using CQRS.Domain.Commands.Responses;
using CQRS.Infrastructure.DbModel;
using CQRS.Infrastructure.Repositories.Interfaces;
using MediatR;
using Nelibur.ObjectMapper;

namespace CQRS.Domain.Commands.Handlers
{
    public class CreateScheduleHandler : IRequestHandler<CreateScheduleRequest, CreateScheduleResponse>
    {
        private readonly IScheduleRepository _scheduleRepository;
        public CreateScheduleHandler(IScheduleRepository scheduleRepository)
        {
            _scheduleRepository = scheduleRepository;
        }
        public async Task<CreateScheduleResponse> Handle(CreateScheduleRequest request, CancellationToken cancellationToken)
        {
            var schedule = TinyMapper.Map<ScheduleDbModel>(request);
            var result = await _scheduleRepository.AddAsync(schedule);
            return TinyMapper.Map<CreateScheduleResponse>(result);
        }
    }
}
