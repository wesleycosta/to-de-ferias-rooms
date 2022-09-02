using ToDeFerias.Rooms.Domain.Entities;

namespace ToDeFerias.Rooms.Domain.Interfaces.Services;

public interface IRoomService
{
    public Task<Room> Add(Room room);
    public Task Update(Room room);
    public Task Remove(Guid id);
}
