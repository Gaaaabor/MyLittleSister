using System.Collections.Generic;

public class LabelManager : SingletonBase<LabelManager>
{
    public List<Label> Labels;

    public bool LabelsVisible;

    private void Start()
    {
        if (LabelsVisible)
        {
            ShowLabels();
        }
        else
        {
            HideLabels();
        }
    }

    public void RegisterLabel(Label label)
    {
        Labels.Add(label);
    }

    public void ShowLabels()
    {
        LabelsVisible = true;
        Labels.ForEach(x => x.ShowLabel());
    }

    public void HideLabels()
    {
        LabelsVisible = false;
        Labels.ForEach(x => x.HideLabel());
    }
}