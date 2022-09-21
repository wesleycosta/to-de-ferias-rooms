using Microsoft.AspNetCore.Mvc;
using System.Net;
using ToDeFerias.Core.Notifier.DTOs;

namespace ToDeFerias.Core.Notifier;

public abstract class NotifierControllerBase : ControllerBase
{
    public readonly INotifier Notifier;

    protected NotifierControllerBase(INotifier notifier) =>
        Notifier = notifier;

    protected bool IsValid() =>
        !Notifier.HasNotification();

    public IActionResult CustomResponse<T>(object? result = null,
                                           HttpStatusCode statusCode = HttpStatusCode.OK,
                                           string url = "") where T : class, new()
    {
        if (!IsValid())
            return BadRequestResponse();

        if (result is null)
            return NoContent();

        return HttpStatusCodeRespose<T>(result, statusCode, url);
    }

    private IActionResult BadRequestResponse() =>
        BadRequest(new BadRequestResponseDto(Notifier.GetNotifications()));

    private IActionResult HttpStatusCodeRespose<T>(object? result = null,
                                                   HttpStatusCode statusCode = HttpStatusCode.OK,
                                                   string url = "") where T : class, new()
    {
        switch (statusCode)
        {
            case HttpStatusCode.Created:
            return Created(url, new
            {
                sucess = true,
                data = result
            });

            case HttpStatusCode.OK:
            return Ok(new
            {
                sucess = true,
                data = result
            });
        }

        return StatusCode((int)statusCode, new
        {
            sucess = true,
            data = result
        });
    }

    public void Notify(string message) =>
        Notifier.Send(new Notification(message));
}
