using UnityEngine;

public class SpeedCommand : CommandBase
{
    public SpeedCommand()
    {
        ShortHand = "s";
        CommandText = "speed";
        ParameterCount = 1;
    }

    public override CommandResult Execute(string[] parameters)
    {
        var commandResult = base.Execute(parameters);
        if (!commandResult)
        {
            return commandResult;
        }

        var rawTimeScaleValue = parameters[ParameterCount - 1];
        float timeScaleValue;
        if (!float.TryParse(rawTimeScaleValue, out timeScaleValue))
        {
            commandResult = new CommandResult(string.Format("Please provide a floating point number instead of ({0})!", rawTimeScaleValue), false);
            Debug.Log(commandResult);
            return commandResult;
        }

        BuffManager.Instance.SetTimeScale(timeScaleValue);        

        commandResult = new CommandResult(string.Format("TimeScale set to ({0})!", timeScaleValue));
        Debug.Log(commandResult);
        return commandResult;
    }
}