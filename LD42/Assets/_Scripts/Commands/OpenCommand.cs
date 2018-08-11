using System;
using UnityEngine;

namespace Assets._Scripts.Commands
{
    public class OpenCommand : CommandBase
    {
        public override void Execute(string[] parameters)
        {
            var index = Math.Min(ParameterCount - 1, 0);

            Debug.Log(string.Format("Item with id ({0}) opened!", parameters[index]));
        }
    }
}
