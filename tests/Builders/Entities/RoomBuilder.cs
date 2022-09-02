using AutoFixture;
using ToDeFerias.Rooms.Domain.Entities;

namespace ToDeFerias.Rooms.DomainTests.Builders.Entities;

internal sealed class RoomBuilder : BuilderBase<Room, RoomBuilder>
{
    public override RoomBuilder BuildDefault()
    {
        Object = Fixture.Create<Room>();
        Object.SetId(Guid.Empty);

        return this;
    }
}
