using UnityEngine;

public class EnableCommand : CommandBase
{
    public EnableCommand()
    {
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
        var managedGameObject = GameObjectManager.Instance.GetManagedGameObject(target);
        if (managedGameObject == null)
        {
            commandResult = new CommandResult(string.Format("Item with id ({0}) not found!", target), false);
            Debug.Log(commandResult);
            return commandResult;
        }

        managedGameObject.SetEnabledState();

        commandResult = new CommandResult(string.Format("Item with id ({0}) enabled!", target));
        Debug.Log(commandResult);
        return commandResult;
    }
}