using TMPro;
using UnityEngine;

public class RoomMessagesManager : MonoBehaviour
{

    public Messages msgs;
    public GameObject uiText;

    void Start()
    {
        uiText.GetComponent<TextMeshProUGUI>().text = msgs.MessagesText[0];
    }

    void Update()
    {

    }
}
