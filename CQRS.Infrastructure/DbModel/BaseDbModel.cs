namespace CQRS.Infrastructure.DbModel
{
    public class BaseDbModel
    {
        public Guid Id { get; set; }
        public Guid UserCreated { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid UserLastUpdated { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
