using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class RoomMessagesManager : MonoBehaviour
{
    public int MessageIndex { get; set; } = 0;
    public string Message { get => messages.MessagesText[MessageIndex]; }


    public Messages messages;
    public GameObject uiText;
    public TimerManager timer;

    public TextMeshProUGUI TextMesh => uiText.GetComponentInChildren<TextMeshProUGUI>();
    public Coroutine coroutine;

    private Action messageCallback;
    private float messageTimer;

    void Start()
    {

    }

    public void SetMessage(int messageIndex, float timer = 5, Action func = null)
    {
        messageCallback = func;
        messageTimer = timer;

        if (coroutine != null)
            StopMessages();
        coroutine = StartCoroutine(MessageCoroutine(messageIndex));
    }

    private IEnumerator MessageCoroutine(int messageIndex)
    {
        this.MessageIndex = messageIndex;
        uiText.SetActive(true);
        if(timer != null)
            timer.StopTimer();

        while (MessageIndex <= messages.MessagesText.Length - 1 && !Message.Equals("-"))
        {
            TextMesh.text = Message;
            yield return new WaitForSeconds(messageTimer);
            this.MessageIndex++;
        }

        if(messageCallback != null)
            messageCallback.Invoke();

        this.StopMessages();
    }

    public void StopMessages()
    {
        uiText.SetActive(false);

        if (coroutine != null)
            StopCoroutine(coroutine);
        if(timer != null)
            timer.StartTimer();
        coroutine = null;
        MessageIndex = 0;
    }

    public void ShowNextMessage()
    {
        if (this.MessageIndex != -1 && this.MessageIndex < messages.MessagesText.Length - 1 && !Message.Equals("-"))
            SetMessage(++this.MessageIndex, messageTimer, messageCallback);
        else
            StopMessages();
    }

    public void EnableAndStartTimer(bool enable)
    {
        timer.Enabled = enable;
        if (enable) timer.StartTimer();
    }
}


