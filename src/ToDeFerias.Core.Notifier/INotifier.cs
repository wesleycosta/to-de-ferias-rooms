namespace ToDeFerias.Core.Notifier;

public interface INotifier
{
    bool HasNotification();
    IReadOnlyList<Notification> GetNotifications();
    void Send(Notification notification);
    void Send(string message);
}
