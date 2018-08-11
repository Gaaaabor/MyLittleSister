﻿using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DialogTrigger : MonoBehaviour
{
    public Conversation Conversation;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            StartDialog();
        }
    }

    private void StartDialog()
    {
        PlayerController.Instance.IdlePlayer();
        DialogManager.Instance.StartConversation(Conversation);
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
}