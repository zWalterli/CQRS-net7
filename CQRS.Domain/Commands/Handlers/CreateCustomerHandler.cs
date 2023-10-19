using CQRS.Domain.Commands.Requests;
using CQRS.Domain.Commands.Responses;
using MediatR;

namespace CQRS.Domain.Commands.Handlers
{
    public class CreateCustomerHandler : IRequestHandler<CreateCustomerRequest, CreateCustumerResponse>
    {
        public async Task<CreateCustumerResponse> Handle(CreateCustomerRequest request, CancellationToken cancellationToken)
        {
            // Verifica se cliente cadastrado
            // Valida os dados
            // Insere o cliente
            // Envia e-mail de boas vindas

            var result = new CreateCustumerResponse
            {
                Id = Guid.NewGuid(),
                Name = "Walterli Valadares Jr.",
                Email = "walterli.valadares@outlook.com",
                CreateAt = DateTime.Now
            };
            return await Task.FromResult(result);
        }
    }
}
