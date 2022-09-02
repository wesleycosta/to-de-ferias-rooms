using ToDeFerias.Rooms.Domain.Entities;

namespace ToDeFerias.Rooms.Domain.Interfaces.Services;

public interface IRoomTypeService
{
    public Task<RoomType> Add(RoomType roomType);
    public Task<RoomType> Update(RoomType roomType);
    public Task Remove(Guid id);
}
