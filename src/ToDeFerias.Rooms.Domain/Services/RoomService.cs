using ToDeFerias.Rooms.Domain.Entities;
using ToDeFerias.Rooms.Domain.Interfaces.Repositories;
using ToDeFerias.Rooms.Domain.Interfaces.Services;

namespace ToDeFerias.Rooms.Domain.Services;

public sealed class RoomService : IRoomService
{
    private readonly IRoomRepository _roomRepository;
    private readonly IUnitOfWork _unitOfWork;

    public RoomService(IRoomRepository roomRepository,
                       IUnitOfWork unitOfWork)
    {
        _roomRepository = roomRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Room> Add(Room room)
    {
        // TODO: adicionar validação com fluent validation

        var sameNumberedRoom = await _roomRepository.GetByNumber(room.Number);
        if (sameNumberedRoom != null)
        {
            // TODO: adicionar notificação
            return room;
        }

        room.GenerateId();
        _roomRepository.Add(room);

        await _unitOfWork.Commit();
        return room;
    }

    public Task Update(Room room) => throw new NotImplementedException();

    public Task Remove(Guid id) => throw new NotImplementedException();
}
