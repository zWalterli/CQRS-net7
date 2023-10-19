using CQRS.Domain.Commands.Requests;
using CQRS.Domain.Commands.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRS.API.Controllers
{
    [ApiController]
    [Route("api/v1/customer")]
    public class CustomerController : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<CreateCustumerResponse>> Create(
            [FromServices] IMediator mediator,
            [FromBody] CreateCustomerRequest command
        )
        {
            try
            {
                var response = await mediator.Send(command);
                return Ok(response);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
