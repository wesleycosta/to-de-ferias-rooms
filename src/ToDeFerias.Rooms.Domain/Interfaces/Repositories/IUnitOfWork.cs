namespace ToDeFerias.Rooms.Domain.Interfaces.Repositories;

public interface IUnitOfWork
{
    Task<bool> Commit();
}
