using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.Events;

public class WaitForCommand : SingletonBase<WaitForCommand>
{
    public UnityEvent Event;    
    public string CommandText;
    public List<string> RequiredParameters;

    public void OnCommand(string commandText, string[] commandParameters)
    {
        if (!CommandText.Equals(commandText, StringComparison.OrdinalIgnoreCase))
        {
            return;
        }

        if (RequiredParameters == null || !RequiredParameters.Any())
        {
            FireEventAndDestroy();
            return;
        }

        if (commandParameters != null && RequiredParameters.Intersect(commandParameters, StringComparer.OrdinalIgnoreCase).Any())
        {
            FireEventAndDestroy();
        }
    }

    private void FireEventAndDestroy()
    {
        if (Event != null)
        {
            Event.Invoke();
        }

        gameObject.SetActive(false);
        Destroy(this);

    }
}
