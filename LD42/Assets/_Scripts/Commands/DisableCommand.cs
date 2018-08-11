using UnityEngine;

namespace Assets._Scripts.Commands
{
    public class DisableCommand : CommandBase
    {
        public DisableCommand()
        {
            CommandText = "disable";
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

            managedGameObject.SetDisabledState();

            Debug.Log(string.Format("Item with id ({0}) disabled!", target));

            return true;
        }
    }
}
