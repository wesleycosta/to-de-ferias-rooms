using ToDeFerias.Rooms.Domain.Entities;

namespace ToDeFerias.Rooms.Domain.Interfaces.Repositories;

public interface IRepositoryBase<T> where T : Entity
{
    void Add(T entity);
    void Update(T entity);
    Task Remove(Guid id);
    Task<T?> GetById(Guid id);
    Task<IEnumerable<T>> GetAll();
}
