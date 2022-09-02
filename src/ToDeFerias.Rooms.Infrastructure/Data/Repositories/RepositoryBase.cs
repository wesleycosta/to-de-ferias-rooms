using Microsoft.EntityFrameworkCore;
using ToDeFerias.Rooms.Domain.Entities;
using ToDeFerias.Rooms.Domain.Interfaces.Repositories;
using ToDeFerias.Rooms.Infrastructure.Data;

namespace ToDeFerias.Bookings.Infrastructure.Repositories;

public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : Entity
{
    public IUnitOfWork UnitOfWork { get; }

    protected readonly RoomsContext Context;
    protected readonly DbSet<T> DbSet;

    protected RepositoryBase(RoomsContext context,
                             IUnitOfWork unitOfWork)
    {
        Context = context;
        DbSet = context.Set<T>();
        UnitOfWork = unitOfWork;
    }

    public virtual void Add(T entity) =>
        DbSet.Add(entity);

    public virtual void Update(T entity) =>
        DbSet.Update(entity);

    public virtual async Task Remove(Guid id)
    {
        var entity = await GetById(id);
        if (entity is null)
            return;

        DbSet.Remove(entity);
    }

    public virtual async Task<T?> GetById(Guid id) =>
        await DbSet.FirstOrDefaultAsync(p => p.Id == id);

    public virtual async Task<IEnumerable<T>> GetAll() =>
        await DbSet.ToListAsync();

    public virtual void Dispose() =>
        Context?.Dispose();
}
