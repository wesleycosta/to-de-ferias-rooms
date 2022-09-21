using FluentValidation;
using ToDeFerias.Core.Notifier;
using ToDeFerias.Rooms.Domain.Entities;

namespace ToDeFerias.Rooms.Domain.Services.Rooms;

internal sealed class RoomValidation : AbstractValidator<Room>
{
    public RoomValidation()
    {
        RuleFor(room => room.Id)
            .NotEmpty()
            .NotNull()
            .WithMessage(ValidationMessages.TheFieldCannotBeEmpty(nameof(Room.Id)));

        RuleFor(room => room.RoomTypeId)
            .NotEmpty()
            .NotNull()
            .WithMessage(ValidationMessages.TheFieldCannotBeEmpty(nameof(Room.RoomTypeId)));

        RuleFor(room => room.Number)
            .NotEmpty()
            .NotNull()
            .WithMessage(ValidationMessages.TheFieldCannotBeEmpty(nameof(Room.Number)));
    }
}
