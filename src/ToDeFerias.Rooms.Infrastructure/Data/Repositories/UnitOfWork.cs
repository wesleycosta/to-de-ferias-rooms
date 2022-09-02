using ToDeFerias.Rooms.Domain.Interfaces.Repositories;

namespace ToDeFerias.Rooms.Infrastructure.Data.Repositories;

internal sealed class UnitOfWork : IUnitOfWork
{
    private readonly RoomsContext _context;

    public UnitOfWork(RoomsContext roomsContext) =>
        _context = roomsContext;

    public async Task<bool> Commit() =>
        await _context.Commit();
}
