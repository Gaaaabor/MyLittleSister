using UnityEngine;

public class RestartCommand : CommandBase
{
    public RestartCommand()
    {
        ShortHand = "r";
        CommandText = "restart";
        ParameterCount = 0;
    }

    public override CommandResult Execute(string[] parameters)
    {
        var commandResult = base.Execute(parameters);
        if (!commandResult)
        {
            return commandResult;
        }

        PlayerController.Instance.Die();

        commandResult = new CommandResult("Restart command executed!");
        Debug.Log(commandResult);
        return commandResult;
    }
}