namespace ToDeFerias.Rooms.Domain.Entities;

public sealed class Room : Entity
{
    public byte Number { get; private set; }
    public RoomType? Type { get; private set; }

    public Guid RoomTypeId { get; private set; }

    public Room(byte number,
                Guid roomTypeId)
    {
        Number = number;
        RoomTypeId = roomTypeId;
    }
}
