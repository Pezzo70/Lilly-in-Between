using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class RoomMessagesManager : MonoBehaviour
{

    [SerializeField]
    public int MessageIndex { get; set; } = 0;
    public string Message { get => messages.MessagesText[MessageIndex]; }


    public Messages messages;
    public GameObject uiText;

    public TextMeshProUGUI TextMesh => uiText.GetComponentInChildren<TextMeshProUGUI>();
    public Coroutine coroutine;

    void Start()
    {
        uiText.SetActive(false);
    }

    public void SetMessage(int messageIndex, int timer = 5, Action func = null)
    {
        if (coroutine != null)
            StopMessages();
        coroutine = StartCoroutine(MessageCoroutine(messageIndex, timer, func));
    }

    private IEnumerator MessageCoroutine(int messageIndex, int timer = 6, Action func = null)
    {
        this.MessageIndex = messageIndex;
        uiText.SetActive(true);

        while (MessageIndex <= messages.MessagesText.Length - 1 && !Message.Equals("-"))
        {
            TextMesh.text = Message;
            yield return new WaitForSeconds(timer);
            this.MessageIndex++;
        }
        func?.Invoke();

        this.StopMessages();
    }

    public void StopMessages()
    {
        uiText.SetActive(false);

        if(coroutine != null)
            StopCoroutine(coroutine);

        coroutine = null;
        MessageIndex = 0;
    }

    public void ShowNextMessage()
    {
        if (this.MessageIndex != -1 && this.MessageIndex < messages.MessagesText.Length - 1 && !Message.Equals("-"))
            SetMessage(++this.MessageIndex);
        else
            StopMessages();
    }
}


