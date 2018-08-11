using System.Collections.Generic;

namespace Assets._Scripts.Manager
{
    public class LabelManager : SingletonBase<LabelManager>
    {
        public List<Label> Labels;

        public void RegisterLabel(Label label)
        {
            Labels.Add(label);
        }

        public void ShowLabels()
        {
            Labels.ForEach(x => x.ShowLabel());
        }

        public void HideLabels()
        {
            Labels.ForEach(x => x.HideLabel());
        }
    }
}
