using ToDeFerias.Rooms.Domain.Models;

namespace ToDeFerias.Rooms.Domain.Interfaces.Repositories;

public interface IBaseRepository<T> where T : Entity, new()
{
    Task<T> Add(T entity);
    Task<bool> Update(T entity);
    Task<T> GetById(Guid id);
    Task<IEnumerable<T>> GetAll();
}
