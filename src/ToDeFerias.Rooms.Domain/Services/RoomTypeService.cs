using ToDeFerias.Rooms.Domain.Entities;
using ToDeFerias.Rooms.Domain.Interfaces.Services;

namespace ToDeFerias.Rooms.Domain.Services;

public sealed class RoomTypeService : IRoomTypeService
{
    public Task<RoomType> Add(RoomType roomType) => throw new NotImplementedException();
    public Task Remove(Guid id) => throw new NotImplementedException();
    public Task<RoomType> Update(RoomType roomType) => throw new NotImplementedException();
}
