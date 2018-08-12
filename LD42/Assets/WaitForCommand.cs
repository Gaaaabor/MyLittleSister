using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class WaitForCommand : MonoBehaviour
{
    public UnityEvent Event;    
    public List<string> CommandTexts;
    public List<string> RequiredParameters;

    public void OnCommand(string commandText, string[] commandParameters)
    {
        if (!CommandTexts.Contains(commandText, StringComparer.OrdinalIgnoreCase))
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
