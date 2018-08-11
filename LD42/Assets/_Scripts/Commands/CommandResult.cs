public class CommandResult
{
    public string Message { get; private set; }
    public bool IsSuccessful { get; private set; }

    public CommandResult(bool isSuccessful = true)
    {
        Message = string.Empty;
        IsSuccessful = isSuccessful;
    }

    public CommandResult(string message, bool isSuccessful = true)
    {
        Message = message;
        IsSuccessful = isSuccessful;
    }

    public override string ToString()
    {
        return Message;
    }

    public static implicit operator bool(CommandResult commandResult)
    {
        return !ReferenceEquals(commandResult, null) && commandResult.IsSuccessful;
    }
}