using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class DialogManager : SingletonBase<DialogManager>
{
    public List<DialogText> DialogTexts;

    public List<ConversationEvent> eventList;
    public List<ConversationEvent> firedEvent;

    public List<AudioClip> Clips;
    private AudioSource _audio;

    public override void Awake()
    {
        base.Awake();
        var path = Path.Combine(Application.streamingAssetsPath, "Dialogs.json");
        DialogTexts = ParseDialogTexts(path);
        _audio = GetComponent<AudioSource>();
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
#if UNITY_EDITOR
        if (Input.GetKey(KeyCode.A))
        {
            _timer += Time.deltaTime * 100;
        }
#endif
        if (_on)
        {
            _timer += Time.deltaTime;
            if (eventList.FirstOrDefault() == null)
            {
                _on = false;
                Debug.Log("Conversation done");
                return;
            }

            if (eventList.FirstOrDefault().Timestemp <= _timer)
            {
                ShotNextEvent();
            }
        }
    }

    private void ShotNextEvent()
    {
        var nextevent = eventList.FirstOrDefault();
        //Debug.Log(nextevent.Id);

        var dialogText = DialogTexts.FirstOrDefault(x => x.ID.Equals(nextevent.Id, System.StringComparison.OrdinalIgnoreCase));
        if (dialogText != null)
        {
            DialogVisualiser.Instance.UpdateDialogText(dialogText.Body, dialogText.Owner, dialogText.GetPlacement(), nextevent.Clear, nextevent.IsModal);
        }
        else
        {
            DialogVisualiser.Instance.UpdateDialogText(string.Empty, string.Empty, DialogPlacement.None, nextevent.Clear, nextevent.IsModal);
        }

        PlayerController.Instance.SetPlayerState(nextevent.PlayerState);

        PlayClip(dialogText);

        nextevent.Event.Invoke();
        firedEvent.Add(nextevent);
        eventList.Remove(nextevent);
        //Debug.Log(nextevent.Id + " Done");
    }

    private void PlayClip(DialogText dialogText)
    {
        if (dialogText == null) return;

        _audio.Stop();

        AudioClip clip = Clips.FirstOrDefault(x => x.name.Equals(dialogText.ID, StringComparison.OrdinalIgnoreCase));
        if (clip != null)
        {
            _audio.clip = clip;
            _audio.Play();
        }
    }

    public void StartTimer()
    {
        _on = true;
    }

    public void PauseTimer()
    {
        _on = false;
    }

    public void StartConversation(Conversation conversation, DialogTrigger trigger)
    {
        if (eventList.Count != 0) return;
        eventList = conversation.Conversations;
        //Debug.Log(trigger.gameObject.name);
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