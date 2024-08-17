using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;

namespace LDCR.Infrastructure.Middlewares;

public class ExceptionHandlerMiddleware : IExceptionHandler
{

    public ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
