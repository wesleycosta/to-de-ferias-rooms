namespace ToDeFerias.Rooms.Domain.Models;

public abstract class Room : Entity
{
    public byte Number { get; private set; }
    public RoomType Type { get; private set; }

    public Guid RoomTypeId { get; private set; }
}
