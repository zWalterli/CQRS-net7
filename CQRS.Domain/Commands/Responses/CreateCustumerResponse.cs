namespace CQRS.Domain.Commands.Responses
{
    public class CreateCustumerResponse
    {
        public Guid Id{ get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime CreateAt { get; set; }
    }
}
