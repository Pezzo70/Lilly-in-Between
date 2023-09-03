using TMPro;
using UnityEngine;

public class RoomMessagesManager : MonoBehaviour
{

    public Messages msgs;
    public GameObject uiText;
    public TextMeshProUGUI TextMesh => uiText.GetComponentInChildren<TextMeshProUGUI>();

    void Start()
    {
        uiText.SetActive(false);
    }

    void Update()
    {

    }

    public void SetMessage(int messageIndex, int? timer = null) 
    {
        uiText.SetActive(true);
        TextMesh.text = msgs.MessagesText[messageIndex];
    }
}
