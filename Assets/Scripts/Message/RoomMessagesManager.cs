using System.Collections;
using TMPro;
using UnityEngine;

public class RoomMessagesManager : MonoBehaviour
{

    public Messages msgs;
    public GameObject uiText;
    public TextMeshProUGUI TextMesh => uiText.GetComponentInChildren<TextMeshProUGUI>();

    public Coroutine coroutine;

    void Start()
    {
        uiText.SetActive(false);
    }

    void Update()
    {

    }

    public void SetMessage(int messageIndex, int timer = 5) 
    {
        if (coroutine != null)
            StopMessages();
        coroutine = StartCoroutine(MessageCoroutine(messageIndex, timer));
    }

    private IEnumerator MessageCoroutine(int messageIndex, int timer = 5) 
    {
        uiText.SetActive(true);
        TextMesh.text = msgs.MessagesText[messageIndex];
        yield return new WaitForSeconds(timer);
        uiText.SetActive(false);
    }

    public void StopMessages() 
    {
        uiText.SetActive(false);
        StopCoroutine(coroutine);
        coroutine = null;
    }

    public void SkipMessage()
    { 
        
    }
}
