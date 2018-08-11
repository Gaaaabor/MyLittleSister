using UnityEngine;

namespace Assets._Scripts.Commands
{
    public class ActivateCommand : CommandBase
    {
        public ActivateCommand()
        {
            CommandText = "activate";
            ParameterCount = 1;
        }

        public override bool Execute(string[] parameters)
        {
            if (!base.Execute(parameters))
            {
                return false;
            }

            Debug.Log(string.Format("Item with id ({0}) activated!", parameters[ParameterCount - 1]));

            return true;
        }
    }
}
