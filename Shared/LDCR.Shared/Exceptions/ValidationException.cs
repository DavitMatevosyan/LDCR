using System.Net;

namespace LDCR.Shared.Exceptions;

public class ValidationException(string ex, params (string Key, string Value)[] extensionParams) 
    : BaseException(ex, (int)HttpStatusCode.BadRequest, extensionParams)
{
}
