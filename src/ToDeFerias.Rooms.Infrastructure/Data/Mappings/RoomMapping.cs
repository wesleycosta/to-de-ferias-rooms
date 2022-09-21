﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDeFerias.Rooms.Domain.Entities;

namespace ToDeFerias.Rooms.Infrastructure.Data.Mappings;

public sealed class RoomMapping : IEntityTypeConfiguration<Room>
{
    public void Configure(EntityTypeBuilder<Room> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id)
               .HasColumnName("Id");

        builder.Property(p => p.Number)
               .IsRequired()
               .HasColumnName("Number");

        builder.HasOne(p => p.Type)
               .WithMany(p => p.Rooms)
               .HasForeignKey(p => p.RoomTypeId);

        builder.ToTable("Rooms");
    }
}
