using LDCR.Shared.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace LDCR.Infrastructure.Controllers;

public static class ResultUtils
{
    public static IActionResult ConvertToProblem<T>(this CommandResult<T> command)
    {
        var extensions = new Dictionary<string, object>();
        if (command.FailureReasons is not null && command.FailureReasons.Any())
        {
            for (int i = 1; i <= command.FailureReasons.Count; i++)
            {
                extensions.Add($"Failure Reason {i}", command.FailureReasons[i - 1]);
            }
        }

        var problem = new ProblemDetails()
        {
            Detail = command.FailureType.ToString(),
            Status = (int)command.FailureType.GetStatusCode(),
            Extensions = extensions!
        };

        return new ObjectResult(problem);
    }

    private static HttpStatusCode GetStatusCode(this FailureType failureType)
    {
        if (failureType == FailureType.Undefined || failureType == FailureType.None)
            return HttpStatusCode.OK;

        return (HttpStatusCode)failureType;
    }
}
