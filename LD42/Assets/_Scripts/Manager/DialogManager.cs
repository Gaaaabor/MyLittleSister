using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class DialogManager : SingletonBase<DialogManager>
{
    public List<DialogText> DialogTexts;

    [TextArea]
    private string TestJson = @"
[{
""SoundFile"":""file_01.mp3"",
""Placement"":""TopLeft"",
""Owner"":""The administrator"",
""Body"":""Oh hai world!""
},
{
""SoundFile"":""file_02.mp3"",
""Placement"":""TopRight"",
""Owner"":""Sound from the bushes"",
""Body"":""Hello adventurer!""
}]";

    private void Awake()
    {
        //DialogTexts = ParseDialogTexts(string.Empty);
    }

    [ContextMenu("ParseTest")]
    private void ParseTest()
    {
        try
        {
            DialogTexts = JsonUtility.FromJson<DialogText[]>(TestJson).ToList();
        }
        catch (System.Exception ex)
        {
            Debug.Log(ex);
        }
    }

    private List<DialogText> ParseDialogTexts(string path)
    {
        var rawJson = File.ReadAllText(path);
        var dialogTexts = JsonUtility.FromJson<DialogText[]>(rawJson);
        return dialogTexts.ToList();
    }
}