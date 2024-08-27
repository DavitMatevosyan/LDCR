namespace LDCR.Shared.Results;

public class CommandResult<T> where T : new()
{
    public T Result { get; set; }
    public FailureType FailureType { get; private set; }
    public List<string>? FailureReasons { get; private set; }

    /// <summary>
    /// Success Constructor
    /// </summary>
    /// <param name="command"></param>
    public CommandResult(T result)
    {
        Result = result;
        FailureReasons ??= [];
        FailureType = FailureType.None;
    }

    /// <summary>
    /// Failure Constructor
    /// </summary>
    /// <param name="result"></param>
    /// <param name="failureType"></param>
    /// <param name="failureReason"></param>
    public CommandResult(T result, FailureType failureType, List<string> failureReason)
    {
        Result = result;
        FailureType = failureType;
        FailureReasons = failureReason;
    }

    public bool IsSuccess => FailureType == FailureType.None;

    public void AddFailures(IEnumerable<string> failures, FailureType type = FailureType.Undefined)
    {
        FailureReasons?.AddRange(failures);

        if (type != FailureType.Undefined)
            FailureType = type;
    }
}