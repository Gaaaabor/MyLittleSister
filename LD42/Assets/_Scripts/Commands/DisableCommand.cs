using System.Linq;
using UnityEngine;

public class DisableCommand : CommandBase
{
    public DisableCommand()
    {
        ShortHand = "d";
        CommandText = "disable";
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
            managedGameObject.SetDisabledState();
        }

        commandResult = new CommandResult(string.Format("Item with id ({0}) disabled!", target));
        Debug.Log(commandResult);
        return commandResult;
    }
}