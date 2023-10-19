using CQRS.Domain.Commands.Responses;
using MediatR;

namespace CQRS.Domain.Commands.Requests
{
    public class CreateCustomerRequest : IRequest<CreateCustumerResponse>
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
