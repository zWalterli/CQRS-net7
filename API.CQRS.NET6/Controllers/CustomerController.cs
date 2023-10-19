using CQRS.Domain.Base;
using CQRS.Domain.Commands.Requests;
using CQRS.Domain.Commands.Responses;
using CQRS.Domain.Commands.Schedule.Responses;
using CQRS.Infrastructure.Repositories.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Nelibur.ObjectMapper;

namespace CQRS.API.Controllers
{
    [ApiController]
    [Route("api/v1/customer")]
    public class CustomerController : BaseController
    {
        private readonly IMediator _mediator;
        private readonly IScheduleRepository _scheduleRepository;
        public CustomerController(IScheduleRepository scheduleRepository, IMediator mediator)
        {
            _mediator = mediator;
            _scheduleRepository = scheduleRepository;
        }
        
        [HttpPost]
        public async Task<ActionResult<ResponseAPI<CreateScheduleResponse>>> Create(
            [FromBody] CreateScheduleRequest command
        )
        {
            var response = await _mediator.Send(command);
            return Success(response);
        }

        [HttpGet]
        public async Task<ActionResult<ResponseAPI<List<GetPagedScheduleResponse>>>> Get([FromRoute] int page, [FromRoute] int pageSize)
        {
            var dbModel = _scheduleRepository.ListAsync(page, pageSize);
            var response = TinyMapper.Map<List<GetPagedScheduleResponse>>(dbModel);
            return Success(response);
        }
    }
}
