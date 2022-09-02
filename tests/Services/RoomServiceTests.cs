using FluentAssertions;
using Moq;
using ToDeFerias.Rooms.Domain.Interfaces.Repositories;
using ToDeFerias.Rooms.Domain.Services;
using ToDeFerias.Rooms.DomainTests.Builders.Entities;

namespace ToDeFerias.Rooms.DomainTests.Services;

public sealed class RoomServiceTests
{
    private readonly RoomService _sut;
    private readonly Mock<IRoomRepository> _roomRepository;
    private readonly Mock<IUnitOfWork> _unitOfWork;

    public RoomServiceTests()
    {
        _roomRepository = new Mock<IRoomRepository>();
        _unitOfWork = new Mock<IUnitOfWork>();

        _sut = new RoomService(_roomRepository.Object,
                               _unitOfWork.Object);
    }

    [Fact]
    public async Task Add_Should_RegisterRoom_When_DataIsValid()
    {
        // arrange
        var room = new RoomBuilder().BuildDefault()
                                    .Create();

        // act
        var result = await _sut.Add(room);

        // assert
        result.Should().NotBeNull();
        result.Id.Should().NotBeEmpty();

        _roomRepository.Verify(p => p.Add(room), Times.Once);
        _unitOfWork.Verify(p => p.Commit(), Times.Once);
    }
}
