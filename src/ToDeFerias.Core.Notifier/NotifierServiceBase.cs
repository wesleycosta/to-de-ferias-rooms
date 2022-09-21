using FluentValidation;
using FluentValidation.Results;

namespace ToDeFerias.Core.Notifier;

public abstract class NotifierServiceBase
{
    private readonly INotifier _notifier;

    protected NotifierServiceBase(INotifier notifier)
        => _notifier = notifier;

    protected bool HasNotification() =>
        _notifier.HasNotification();

    protected void Notify(string message) =>
        _notifier.Send(message);

    protected void Notify(ValidationResult validationResult)
    {
        foreach (var erro in validationResult.Errors)
            Notify(erro.ErrorMessage);
    }

    protected bool ExecuteValidation<TV, TE>(TV validation, TE model) where TV : AbstractValidator<TE> 
    {
        var validator = validation.Validate(model);

        if (validator.IsValid)
            return true;

        Notify(validator);
        return false;
    }
}
