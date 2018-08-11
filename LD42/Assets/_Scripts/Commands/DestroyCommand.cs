using UnityEngine;

namespace Assets._Scripts.Commands
{
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

            Debug.Log(string.Format("Item with id ({0}) destroyed!", parameters[ParameterCount - 1]));

            return true;
        }
    }
}
