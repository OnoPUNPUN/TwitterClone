

namespace TwitterClone.Domain.Entities
{
    public class BaseEntity
    {
        public Guid Id { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime ModifiedAt { get; private set; }
        public Guid CreatedBy { get; private set; }
        public Guid ModifiedBy { get; private set; }

        public BaseEntity()
        {
            Id = Guid.NewGuid();
            CreatedAt = DateTime.UtcNow;
        }

        protected BaseEntity(Guid id)
        {
            Id = id;
            CreatedAt = DateTime.UtcNow;
        }

        public virtual string DescribeRecord()
        {
            return $"Id: {Id}, CreatedAt: {CreatedAt:o}, ModifiedAt: {ModifiedAt:o}";
        }
    }
}
