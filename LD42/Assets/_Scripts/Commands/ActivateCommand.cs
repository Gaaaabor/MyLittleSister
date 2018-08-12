using System.Linq;
using UnityEngine;

public class ActivateCommand : CommandBase
{
    public ActivateCommand()
    {
        ShortHand = "a";
        CommandText = "activate";
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
        var managedGameObjects = GameObjectManager.Instance.GetManagedGameObjects(target);
        if (managedGameObjects == null || !managedGameObjects.Any())
        {
            commandResult = new CommandResult(string.Format("Item with id ({0}) not found!", target), false);
            Debug.Log(commandResult);
            return commandResult;
        }

        foreach (var managedGameObject in managedGameObjects)
        {
            managedGameObject.SetActivatedState();
        }

        commandResult = new CommandResult(string.Format("Item with id ({0}) activated!", target));
        Debug.Log(commandResult);
        return commandResult;
    }
}