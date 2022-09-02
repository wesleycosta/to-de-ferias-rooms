using ToDeFerias.Bookings.Infrastructure.Repositories;
using ToDeFerias.Rooms.Domain.Entities;
using ToDeFerias.Rooms.Domain.Interfaces.Repositories;

namespace ToDeFerias.Rooms.Infrastructure.Data.Repositories;

public sealed class RoomTypeRepository : RepositoryBase<RoomType>, IRoomTypeRepository
{
    public RoomTypeRepository(RoomsContext context, IUnitOfWork unitOfWork)
        : base(context, unitOfWork)
    {
    }
}
