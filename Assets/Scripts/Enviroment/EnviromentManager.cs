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
            case "Wardrobe": { break; }
            case "Chest": { break; }
            case "Desk": { break; }
            case "Plant": { break; }
            case "Books": { break; }
            case "Toys": { break; }
        }
    }    
}
