using UnityEngine;

namespace Assets._Scripts.Commands
{
    public class EnableCommand : CommandBase
    {
        public EnableCommand()
        {
            CommandText = "enable";
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

            managedGameObject.SetEnabledState();

            Debug.Log(string.Format("Item with id ({0}) enabled!", target));

            return true;
        }
    }
}
