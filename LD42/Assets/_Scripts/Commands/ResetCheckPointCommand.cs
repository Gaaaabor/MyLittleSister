using UnityEngine;

namespace Assets._Scripts.Commands
{
    public class ResetCheckPointCommand : CommandBase
    {
        public ResetCheckPointCommand()
        {
            CommandText = "reset";
            ParameterCount = 1;
        }

        public override bool Execute(string[] parameters)
        {
            if (!base.Execute(parameters))
            {
                return false;
            }

            Debug.Log(string.Format("Item with id ({0}) reseted!", parameters[ParameterCount - 1]));

            return true;
        }
    }
}
