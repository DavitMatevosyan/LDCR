using LDCR.Shared.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LDCR.Infrastructure.Middlewares;

public class GlobalExceptionHandlerMiddleware : IExceptionHandler
{
    // add logger
    // add improvements on how the extensions are used

    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        var details = new ProblemDetails
        {
            Instance = httpContext.Request.Path,
            Title = exception.Message
        };

        if (exception is BaseException ldcrExcetion)
        {
            details.Status = ldcrExcetion.StatusCode;

            foreach (var ext in ldcrExcetion.Extensions)
            {
                details.Extensions.Add(ext.Key, ext.Value);
            }
        }
        else
        {
            details.Status = httpContext.Response.StatusCode;
        }

        await httpContext.Response.WriteAsJsonAsync(details, cancellationToken).ConfigureAwait(false);

        return true;
    }
}
