using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using ToDeFerias.Rooms.Domain.Interfaces.Repositories;

namespace ToDeFerias.Rooms.Infrastructure.Data;

public sealed class RoomsContext : DbContext, IUnitOfWork
{
    public RoomsContext(DbContextOptions<RoomsContext> options) : base(options)
    {
        ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        ChangeTracker.AutoDetectChangesEnabled = false;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        foreach (var property in modelBuilder.Model
                                             .GetEntityTypes()
                                             .SelectMany(p => p.GetProperties()
                                                               .Where(p => p.ClrType == typeof(string))))
            property.SetColumnType("VARCHAR(255)");

        modelBuilder.Ignore<ValidationResult>();

        base.OnModelCreating(modelBuilder);
    }

    public async Task<bool> Commit()
        => await SaveChangesAsync() > 0;
}
