using UnityEngine;

public class DestroyCommand : CommandBase
{
    public DestroyCommand()
    {
        CommandText = "destroy";
        ParameterCount = 1;
    }

    public override bool Execute(string[] parameters)
    {
        if (!base.Execute(parameters))
        {
            return false;
        }

        var target = parameters[ParameterCount - 1];
        var managedGameObject = GameObjectManager.Instance.GetManagedGameObject(target);
        if (managedGameObject == null)
        {
            Debug.Log(string.Format("Item with id ({0}) not found!", target));
            return false;
        }

        managedGameObject.SetDestroyedState();

        Debug.Log(string.Format("Item with id ({0}) destroyed!", target));

        return true;
    }
}