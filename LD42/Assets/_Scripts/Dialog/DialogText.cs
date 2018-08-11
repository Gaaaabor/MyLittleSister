using System;
using System.Collections.Generic;

[Serializable]
public class DialogText
{
    public string SoundFile;
    public string Placement;
    public string Owner;
    public string Body;

    public DialogPlacement GetPlacement()
    {
        return (DialogPlacement)Enum.Parse(typeof(DialogPlacement), Placement);
    }
}

[Serializable]
public class DialogTextCollection
{
    public List<DialogText> DialogTexts;
}