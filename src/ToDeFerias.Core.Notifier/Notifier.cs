﻿namespace ToDeFerias.Core.Notifier;

internal sealed class Notifier : INotifier
{
    private readonly List<Notification> _notifications;

    public Notifier() =>
        _notifications = new List<Notification>();

    public bool HasNotification() =>
        _notifications.Any();

    public IReadOnlyList<Notification> GetNotifications() =>
        _notifications;

    public void Send(Notification notification) =>
        _notifications.Add(notification);

    public void Send(string message) =>
        Send(new Notification(message));
}
