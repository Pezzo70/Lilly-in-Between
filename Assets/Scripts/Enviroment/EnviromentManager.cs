using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class EnviromentManager : MonoBehaviour
{
    public GameObject enviromentItens;
    public RoomMessagesManager roomMessagesManager;
    public ParticleSystem particle;

    private bool test = false;

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
                    test = true;
                    interactedItem.GetComponent<BoxCollider2D>().enabled = false;
                    roomMessagesManager.SetMessage(4, 5, () => FindCollectable("Diary"));
                    break;
                }
            case "Chest":
                {
                    interactedItem.GetComponent<BoxCollider2D>().enabled = false;
                    roomMessagesManager.SetMessage(7, 5, () => FindCollectable("Ball"));
                    break;
                }
            case "Desk":
                {
                    interactedItem.GetComponent<BoxCollider2D>().enabled = false;
                    roomMessagesManager.SetMessage(13, 5, () => FindCollectable("ToyOctopus"));
                    break;
                }
            case "Plant":
                {
                    interactedItem.GetComponent<BoxCollider2D>().enabled = false;
                    roomMessagesManager.SetMessage(18, 5, () => FindCollectable("SparkKey"));
                    break;
                }
            case "Books":
                {
                    interactedItem.GetComponent<BoxCollider2D>().enabled = false;
                    roomMessagesManager.SetMessage(15);
                    break;
                }
            case "Toys":
                {
                    interactedItem.GetComponent<BoxCollider2D>().enabled = false;
                    roomMessagesManager.SetMessage(10);
                    break;
                }
            case "ToyOctopus":
            case "Diary":
            case "Ball":
            case "SparkKey":
                Destroy(interactedItem, 0.05f);
                particle.transform.position = interactedItem.transform.position;
                particle.Play();
                break;
        }
    }

    public void FindCollectable(string name)
    {
        var obj = enviromentItens.transform.Find("Collectables").Find(name);
        GameObject collectable = enviromentItens.transform.Find("Collectables").Find(name).gameObject;
        collectable.SetActive(true);
        StartCoroutine(AnimateItem(collectable));
    }

    public IEnumerator AnimateItem(GameObject collectable)
    {
        collectable.GetComponent<SpriteRenderer>().sortingOrder = 7;

        Vector2 initialPosition = collectable.transform.position;
        Vector2 vector = initialPosition;
        float seconds = 0.03f;
        float movement = 0.25f;
        do
        {
            collectable.transform.position = vector;
            yield return new WaitForSeconds(seconds);
            vector.y += movement;
        } while (vector.y <= initialPosition.y + 0.5);

        do
        {
            collectable.transform.position = vector;
            yield return new WaitForSeconds(seconds);
            vector.y -= movement;
        } while (vector.y >= initialPosition.y - 0.5);

        do
        {
            collectable.transform.position = vector;
            yield return new WaitForSeconds(seconds);
            vector.y += movement;
        } while (vector.y <= initialPosition.y);

        collectable.GetComponent<SpriteRenderer>().sortingOrder = 5;
    }
}
