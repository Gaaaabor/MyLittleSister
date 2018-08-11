using UnityEngine;

namespace Assets._Scripts.Commands
{
    public class CheatModeCommand : CommandBase
    {
        public CheatModeCommand()
        {
            CommandText = "cheatmode";
            ParameterCount = 1;
        }

        public override bool Execute(string[] parameters)
        {
            if (!base.Execute(parameters))
            {
                return false;
            }

            var rawCheatMode = parameters[ParameterCount - 1];
            bool cheatMode;
            if (bool.TryParse(rawCheatMode, out cheatMode))
            {
                //TODO: insert cheatmode logic here

                Debug.Log(string.Format("Cheatmode {0}!", cheatMode ? "enabled" : "disabled"));
                return true;
            }

            Debug.Log(string.Format("Invalid parameter for Cheatmode {0}!", rawCheatMode));
            return false;
        }
    }
}
