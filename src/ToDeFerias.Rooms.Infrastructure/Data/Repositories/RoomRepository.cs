using Microsoft.EntityFrameworkCore;
using ToDeFerias.Bookings.Infrastructure.Repositories;
using ToDeFerias.Rooms.Domain.Entities;
using ToDeFerias.Rooms.Domain.Interfaces.Repositories;

namespace ToDeFerias.Rooms.Infrastructure.Data.Repositories;

public sealed class RoomRepository : RepositoryBase<Room>, IRoomRepository
{
    public RoomRepository(RoomsContext context, IUnitOfWork unitOfWork)
        : base(context, unitOfWork)
    {
    }

    public async Task<Room?> GetByNumber(byte number)
        => await DbSet.FirstOrDefaultAsync(p => p.Number.Equals(number));
}
