namespace ToDeFerias.Rooms.Domain.Entities
{
    public abstract class Entity
    {
        public Guid Id { get; protected set; }

        public void GenerateId()
            => Id = Guid.NewGuid();

        public void SetId(Guid id)
            => Id = id;
    }
}
