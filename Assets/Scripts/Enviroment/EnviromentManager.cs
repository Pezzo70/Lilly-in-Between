using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnviromentManager : MonoBehaviour
{
    public GameObject enviromentItens;
    public RoomMessagesManager roomMessagesManager;

    public void Start()
    {
        
    }

    public void OnInteract(GameObject interactedItem)
    {
        switch (interactedItem.name)
        {
            case "Bed":
            {
                interactedItem.gameObject.GetComponent<BoxCollider2D>().enabled = false;
                string[] dreamItens = new string[] { "Wardrobe", "Chest", "Desk", "Plant", "Books", "Toys" };
                foreach (var item in dreamItens)
                    enviromentItens.transform.Find(item).gameObject.SetActive(true);

                break;
            }
            case "Wardrobe": 
                {
                    interactedItem.GetComponent<BoxCollider2D>().enabled = false;
                    roomMessagesManager.SetMessage(0);
                    break; 
                }
            case "Chest": 
                {
                    interactedItem.GetComponent<BoxCollider2D>().enabled = false;
                    roomMessagesManager.SetMessage(1);
                    break; 
                }
            case "Desk": 
                {
                    interactedItem.GetComponent<BoxCollider2D>().enabled = false;
                    roomMessagesManager.SetMessage(1);
                    break; 
                }
            case "Plant": 
                { 
                    interactedItem.GetComponent<BoxCollider2D>().enabled = false;
                    roomMessagesManager.SetMessage(1);
                    break; 
                }
            case "Books": 
                {
                    interactedItem.GetComponent<BoxCollider2D>().enabled = false;
                    roomMessagesManager.SetMessage(1);
                    break; 
                }
            case "Toys": 
                {
                    interactedItem.GetComponent<BoxCollider2D>().enabled = false;
                    roomMessagesManager.SetMessage(1);
                    break; 
                }
        }
    }    
}
