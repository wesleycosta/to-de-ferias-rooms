using ToDeFerias.Core.Notifier;

namespace ToDeFerias.Rooms.Api.Controllers;

public abstract class MainController : NotifierControllerBase
{
    protected MainController(INotifier notifier) : base(notifier)
    {
    }
}
