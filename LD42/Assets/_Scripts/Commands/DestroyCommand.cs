using UnityEngine;

namespace Assets._Scripts.Commands
{
    public class DestroyCommand : CommandBase
    {
        public override void Execute(string[] parameters)
        {
            Debug.Log(string.Format("Item with id ({0}) destroyed!", parameters[ParameterCount - 1]));
        }
    }
}
