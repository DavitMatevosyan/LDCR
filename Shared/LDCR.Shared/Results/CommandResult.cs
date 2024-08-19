namespace LDCR.Shared.Results;

public class CommandResult
{
    public object Result { get; set; }
    public FailureType FailureType { get; private set; }
    public List<string>? FailureReasons { get; private set; }

    /// <summary>
    /// Success Constructor
    /// </summary>
    /// <param name="command"></param>
    public CommandResult(object command)
    {
        Result = command;
        FailureReasons ??= [];
        FailureType = FailureType.None;
    }

    /// <summary>
    /// Failure Constructor
    /// </summary>
    /// <param name="command"></param>
    /// <param name="failureType"></param>
    /// <param name="failureReason"></param>
    public CommandResult(object command, FailureType failureType, List<string> failureReason)
    {
        Result = command;
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