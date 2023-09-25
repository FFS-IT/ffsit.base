namespace FFSIT.Model.Entities
{
    public class BaseEntity
    {
        public long Id { get; private set; }

        public DateTime CreatedAt { get; private set; } = DateTime.Now;

        public DateTime UpdatedAt { get; private set; }

        public DateTime? DeletedAt { get; private set; }

        public bool IsDeleted => DeletedAt.HasValue;

        public void Delete()
        {
            DeletedAt = DateTime.Now;
        }
    }
}
