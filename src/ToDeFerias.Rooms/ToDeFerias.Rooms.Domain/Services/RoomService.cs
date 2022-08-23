using ToDeFerias.Rooms.Domain.Interfaces.Services;
using ToDeFerias.Rooms.Domain.Models;

namespace ToDeFerias.Rooms.Domain.Services;

public sealed class RoomService : IRoomService
{
    public Task<Room> Add(Room room) => throw new NotImplementedException();
    public Task Remove(Guid id) => throw new NotImplementedException();
    public Task<Room> Update(Room room) => throw new NotImplementedException();
}
