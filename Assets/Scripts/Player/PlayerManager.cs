using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public RoomMessagesManager roomMessagesManager;

    public void Start()
    {
        roomMessagesManager.SetMessage(0,3);
    }
}
