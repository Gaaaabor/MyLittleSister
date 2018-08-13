using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class DialogText
{
    public string ID;
    public string Placement;
    public string Owner;
    public string Body;

    public DialogPlacement GetPlacement()
    {
        var parsedEnum = DialogPlacement.Top;

        try
        {
            var rawEnum = Enum.Parse(typeof(DialogPlacement), Placement, true);
            if (rawEnum != null)
            {
                parsedEnum = (DialogPlacement)rawEnum;
            }
        }
        catch (Exception ex)
        {
            Debug.Log(ex);
        }

        return parsedEnum;
    }
}

[Serializable]
public class DialogTextCollection
{
    public List<DialogText> DialogTexts;
}