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

    public void SetMessage(int messageIndex, int timer = 5)
    {
        if (coroutine != null)
            StopMessages();
        coroutine = StartCoroutine(MessageCoroutine(messageIndex, timer));
    }

    private IEnumerator MessageCoroutine(int messageIndex, int timer = 6)
    {
        this.MessageIndex = messageIndex;
        TextMesh.text = Message;
        uiText.SetActive(true);

        while (!Message.Equals("-"))
        {
            SkipMessage();
            yield return new WaitForSeconds(timer);
        }

        this.StopMessages();
    }

    public void StopMessages()
    {
        uiText.SetActive(false);
        StopCoroutine(coroutine);

        coroutine = null;
        MessageIndex = 0;
    }

    public void SkipMessage()
    {
        if (this.MessageIndex != -1)
        {
            if (this.MessageIndex < messages.MessagesText.Length - 1)
            {
                this.MessageIndex++;
                if (!Message.Equals("-"))
                {
                    TextMesh.text = Message;
                }
                else
                {
                    StopMessages();
                }
            }
            else
            {
                StopMessages();
            }
        }
    }


    private void RefreshMessage()
    { 
        
    }
}
