using UnityEngine;

public class CheatModeCommand : CommandBase
{
    public CheatModeCommand()
    {
        CommandText = "cheatmode";
        ParameterCount = 0;
    }

    public override bool Execute(string[] parameters)
    {
        if (!base.Execute(parameters))
        {
            return false;
        }

        LabelManager.Instance.ShowLabels();

        Debug.Log("Cheatmode enabled!");
        return true;
    }
}