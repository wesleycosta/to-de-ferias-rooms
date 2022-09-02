using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDeFerias.Rooms.Domain.Entities;

namespace ToDeFerias.Rooms.Infrastructure.Data.Mappings;

public sealed class RoomTypeMapping : IEntityTypeConfiguration<RoomType>
{
    public void Configure(EntityTypeBuilder<RoomType> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id)
               .HasColumnName("Id");

        builder.Property(p => p.Name)
               .IsRequired()
               .HasColumnName("Name");

        builder.ToTable("RoomTypes");
    }
}
