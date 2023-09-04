using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public RoomMessagesManager roomMessagesManager;
    public EnviromentManager enviromentManager;


    public GameObject interactedItem;

    public void Start()
    {
        roomMessagesManager.SetMessage(0,3);
    }

    public void OnInteraction()
    {       
        if(roomMessagesManager.coroutine != null)
            roomMessagesManager.ShowNextMessage();


        if (interactedItem != null)
            enviromentManager.OnInteract(interactedItem);
    }

    public void OnTriggerEnter2D(Collider2D colission) => interactedItem = colission.gameObject;
    

    public void OnTriggerExit2D(Collider2D collision) =>  interactedItem = null;
}
