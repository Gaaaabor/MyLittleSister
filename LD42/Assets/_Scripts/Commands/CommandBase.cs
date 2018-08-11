using UnityEngine;

namespace Assets._Scripts.Commands
{
    public abstract class CommandBase
    {
        public string CommandText { get; protected set; }
        public int ParameterCount { get; protected set; }

        public virtual bool Execute(string[] parameters)
        {
            if (!IsParameterCountValid(parameters))
            {
                InvalidParameterCountMessage();
                return false;
            }

            return true;
        }

        private bool IsParameterCountValid(string[] parameters)
        {
            return parameters != null && ParameterCount == parameters.Length;
        }

        private void InvalidParameterCountMessage()
        {
            Debug.Log(string.Format("Incorrect number of parameters {0} for command {1}", ParameterCount, CommandText));
        }
    }
}
