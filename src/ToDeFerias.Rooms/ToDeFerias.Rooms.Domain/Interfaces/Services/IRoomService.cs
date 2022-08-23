using ToDeFerias.Rooms.Domain.Models;

namespace ToDeFerias.Rooms.Domain.Interfaces.Services;

public interface IRoomService
{
    public Task<Room> Add(Room room);
    public Task<Room> Update(Room room);
    public Task Remove(Guid id);
}
