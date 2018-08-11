using UnityEngine;

namespace Assets._Scripts.Commands
{
    public class SpeedCommand : CommandBase
    {
        public SpeedCommand()
        {
            CommandText = "speed";
            ParameterCount = 1;
        }

        public override bool Execute(string[] parameters)
        {
            if (!base.Execute(parameters))
            {
                return false;
            }

            var rawTimeScaleValue = parameters[ParameterCount - 1];
            float timeScaleValue;
            if (float.TryParse(rawTimeScaleValue, out timeScaleValue))
            {
                BuffManager.Instance.ChangeTime(timeScaleValue);
                Debug.Log(string.Format("TimeScale set to {0}!", timeScaleValue));
                return true;
            }

            Debug.Log(string.Format("Please provide a floating point number instead of ({0})!", rawTimeScaleValue));
            return false;
        }
    }
}
