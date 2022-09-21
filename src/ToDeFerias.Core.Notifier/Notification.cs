namespace ToDeFerias.Core.Notifier;

public sealed class Notification
{
    public string Message { get; }

    public Notification(string message) =>
        Message = message;
}
