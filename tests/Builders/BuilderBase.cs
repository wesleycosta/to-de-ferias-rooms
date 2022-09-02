using AutoFixture;

namespace ToDeFerias.Rooms.DomainTests.Builders;

internal abstract class BuilderBase<TObject, TBuilder>
{
    protected TObject? Object;
    protected readonly Fixture Fixture = new();

    public abstract TBuilder BuildDefault();

    public TObject Create()
    {
        ArgumentNullException.ThrowIfNull(Object);
        return Object;
    }
}
