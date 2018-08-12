using UnityEngine;

public class CheatModeCommand : CommandBase
{
    public CheatModeCommand()
    {
        CommandText = "cheatmode";
        ParameterCount = 0;
    }

    public override CommandResult Execute(string[] parameters)
    {
        var commandResult = base.Execute(parameters);
        if (!commandResult)
        {
            return commandResult;
        }

        LabelManager.Instance.ShowLabels();

        if (WaitForCheatMode.Instance != null)
        {
            WaitForCheatMode.Instance.CheatModeDone(); 
        }

        commandResult = new CommandResult("Cheatmode enabled!");
        Debug.Log(commandResult);
        return commandResult;
    }
}