using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    public RoomMessagesManager roomMessagesManager;
    public EnviromentManager enviromentManager;
    private SpriteRenderer _spriteRenderer;

    public HeartAvailable heartAvailable;

    public GameObject interactedItem;

    private void Awake()
    {
        _spriteRenderer = this.GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 4)
        {
            if (
                ScenesSingleton.instance.ItemsCollected == 4
                && ScenesSingleton.instance.HeartCount >= 8
                && ScenesSingleton.instance.Health == 3
            )
            {
                roomMessagesManager.SetMessage(15, 3);
            }
            else if (ScenesSingleton.instance.ItemsCollected >= 2
                && ScenesSingleton.instance.HeartCount >= 6
                && ScenesSingleton.instance.Health >= 2
            )
            {
                roomMessagesManager.SetMessage(7, 3);
            }
            else
            {

                roomMessagesManager.SetMessage(0, 3);
            }
        }
        else
        {
            roomMessagesManager.SetMessage(0, 3);
        }
    }

    public void OnInteraction()
    {
        if (roomMessagesManager.coroutine != null)
            roomMessagesManager.ShowNextMessage();


        if (interactedItem != null)
            enviromentManager.OnInteract(interactedItem);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        interactedItem = collision.gameObject;
        if (collision.gameObject.tag == "Man")
        {
            if (this.transform.position.y > collision.gameObject.transform.position.y)
                _spriteRenderer.sortingOrder = 5;
            else if (this.transform.position.y < collision.gameObject.transform.position.y)
                _spriteRenderer.sortingOrder = 7;
        }

        if (collision.gameObject.tag == "MonsterPhase2")
        {
            collision.GetComponent<MonsterMovement>().SetPositionToRandomPoint();
            if (ScenesSingleton.instance.HeartCount > 0)
                ScenesSingleton.instance.HeartCount--;
            GameObject.Find("HeartCountText").GetComponent<TextMeshProUGUI>().text = $"x {ScenesSingleton.instance.HeartCount}";
        }

        if (collision.gameObject.tag == "MonsterPhase3")
        {
            heartAvailable.RemoveHeart();
            this.transform.position = new Vector2(14.97f, -41.97f);
        }

    }

    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Man")
        {
            if (this.transform.position.y > other.gameObject.transform.position.y)
                _spriteRenderer.sortingOrder = 5;
            else if (this.transform.position.y < other.gameObject.transform.position.y)
                _spriteRenderer.sortingOrder = 7;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        interactedItem = null;
        if (collision.gameObject.tag == "Man")
            _spriteRenderer.sortingOrder = 6;
    }
}
