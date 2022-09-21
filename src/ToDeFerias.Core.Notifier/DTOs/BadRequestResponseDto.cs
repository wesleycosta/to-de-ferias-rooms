namespace ToDeFerias.Core.Notifier.DTOs;

public sealed class BadRequestResponseDto
{
    public IEnumerable<string> Errors { get; }

    public BadRequestResponseDto(IReadOnlyList<Notification> notifications) =>
        Errors = notifications.Select(p => p?.Message);
}
