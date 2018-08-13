using System.Linq;
using UnityEngine;

public class EnableCommand : CommandBase
{
    public EnableCommand()
    {
        ShortHand = "e";
        CommandText = "enable";
        ParameterCount = 1;
    }

    public override CommandResult Execute(string[] parameters)
    {
        var commandResult = base.Execute(parameters);
        if (!commandResult)
        {
            return commandResult;
        }

        var target = parameters[ParameterCount - 1];
        var managedGameObjects = FindManagedGameObjects(target);
        if (managedGameObjects == null || !managedGameObjects.Any())
        {
            commandResult = new CommandResult(string.Format("Item with id ({0}) not found!", target), false);
            Debug.Log(commandResult);
            return commandResult;
        }

        foreach (var managedGameObject in managedGameObjects)
        {
            managedGameObject.SetEnabledState();
        }

        commandResult = new CommandResult(string.Format("Item with id ({0}) enabled!", target));
        Debug.Log(commandResult);
        return commandResult;
    }
}