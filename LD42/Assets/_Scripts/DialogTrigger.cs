using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DialogTrigger : MonoBehaviour
{
    public Conversation Conversation;

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            StartDialog();
        }
    }

    private void StartDialog()
    {
        DialogManager.Instance.StartConversation(Conversation,this);
    }
}

[Serializable]
public class Conversation
{
    public List<ConversationEvent> Conversations;
}

[Serializable]
public class ConversationEvent
{
    public string Id;
    public bool Clear;
    public bool Stop;
    public float Timestemp;
    public UnityEvent Event;
    public bool IsModal = true;
    public PlayerState PlayerState;
}