using UnityEngine;

namespace Assets._Scripts.Commands
{
    public class OpenCommand : CommandBase
    {
        public OpenCommand()
        {
            CommandText = "Open";
            ParameterCount = 1;
        }

        public override bool Execute(string[] parameters)
        {
            if (!base.Execute(parameters))
            {
                return false;
            }

            Debug.Log(string.Format("Item with id ({0}) opened!", parameters[ParameterCount - 1]));

            return true;
        }
    }
}
