using ToDeFerias.Core.Notifier;
using ToDeFerias.Rooms.Domain.Entities;
using ToDeFerias.Rooms.Domain.Interfaces.Repositories;
using ToDeFerias.Rooms.Domain.Interfaces.Services;

namespace ToDeFerias.Rooms.Domain.Services.Rooms;

public sealed class RoomService : NotifierServiceBase, IRoomService
{
    private readonly IRoomRepository _roomRepository;
    private readonly IUnitOfWork _unitOfWork;

    public RoomService(INotifier notifier,
                       IRoomRepository roomRepository,
                       IUnitOfWork unitOfWork) : base(notifier)
    {
        _roomRepository = roomRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Room> Add(Room room)
    {
        room.GenerateId();

        if (!ExecuteValidation(new RoomValidation(), room))
            return null;

        var sameNumberedRoom = await _roomRepository.GetByNumber(room.Number);
        if (sameNumberedRoom != null)
        {
            Notify($"O quarto com número {room.Number} não foi encontrado!");
            return room;
        }

        _roomRepository.Add(room);
        
        await _unitOfWork.Commit();
        return room;
    }

    public Task Update(Room room) => throw new NotImplementedException();

    public Task Remove(Guid id) => throw new NotImplementedException();
}
