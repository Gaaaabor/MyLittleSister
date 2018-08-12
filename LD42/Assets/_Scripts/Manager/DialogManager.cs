using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class DialogManager : SingletonBase<DialogManager>
{
    public List<DialogText> DialogTexts;

    public List<ConversationEvent> eventList;
    public List<ConversationEvent> firedEvent;


    private void Awake()
    {
        var path = Path.Combine(Application.streamingAssetsPath, "Dialogs.json");
        DialogTexts = ParseDialogTexts(path);
    }

    private List<DialogText> ParseDialogTexts(string path)
    {
        var rawJson = File.ReadAllText(path);
        var dialogTexts = Newtonsoft.Json.JsonConvert.DeserializeObject<DialogTextCollection>(rawJson);
        return dialogTexts.DialogTexts.ToList();
    }

    private bool _on;
    private float _timer;

    private void Start()
    {
        eventList = eventList.OrderBy(x => x.Timestemp).ToList();
    }

    private void Update()
    {
        if (_on)
        {
            _timer += Time.deltaTime;
            if (eventList.FirstOrDefault() != null && eventList.FirstOrDefault().Timestemp <= _timer)
            {
                ShotNextEvent();
            }
        }
    }

    private void ShotNextEvent()
    {
        var nextevent = eventList.FirstOrDefault();
        var dialogText = DialogTexts.FirstOrDefault(x => x.SoundFile.Equals(nextevent.Id, System.StringComparison.OrdinalIgnoreCase));

        DialogVisualiser.Instance.UpdateDialogText(dialogText.Body, dialogText.Owner, dialogText.GetPlacement(), nextevent.Clear, nextevent.IsModal);

        PlayerController.Instance.SetPlayerState(nextevent.PlayerState);

        nextevent.Event.Invoke();
        firedEvent.Add(nextevent);
        eventList.Remove(nextevent);
    }

    public void StartTimer()
    {
        _on = true;
    }

    public void PauseTimer()
    {
        _on = false;
    }

    public void StartConversation(Conversation conversation)
    {
        eventList = conversation.Conversations;

        ResetEvents();
        StartTimer();
    }

    public void ResetEvents()
    {
        firedEvent.Clear();

        eventList = eventList.OrderBy(x => x.Timestemp).ToList();
        _on = false;
        _timer = 0;
    }
}