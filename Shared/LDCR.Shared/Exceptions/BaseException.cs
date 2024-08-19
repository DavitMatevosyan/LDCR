namespace LDCR.Shared.Exceptions;

public class BaseException : Exception
{
    public int StatusCode { get; init; }
    public Dictionary<string, string> Extensions { get; set; }

    public BaseException(string ex, int statusCode, params (string Key, string Value)[] extensionParams)
        : base(ex)
    {
        StatusCode = statusCode;
        Extensions ??= [];

        foreach (var (Key, Value) in extensionParams)
        {
            Extensions.TryAdd(Key, Value);
        }
    }
}
