using ToDeFerias.Rooms.Domain.Entities;

namespace ToDeFerias.Rooms.Domain.Interfaces.Repositories;

public interface IRoomRepository : IRepositoryBase<Room>
{
    Task<Room?> GetByNumber(byte number); 
}
