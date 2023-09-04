
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class EnviromentManager : MonoBehaviour
{
    public GameObject enviromentItens;
    public RoomMessagesManager roomMessagesManager;
    public ScenesTransition scenesTransition;
    public Volume volume;
    public VolumeProfile desiredProfile;

    public ParticleSystem particle;
    public GameObject collectiblesUI;

    public AudioSource audioSource;
    public AudioClip[] audioClip;

    public bool bearAlreadyInteracted = false;

    private float bearLastUseSecond;

    private HeartsManager _heartsManager;

    public void Awake()
    {
        var gameObj = GameObject.FindGameObjectWithTag("HeartsManager");
        if (gameObj != null)
            gameObj.TryGetComponent<HeartsManager>(out _heartsManager);
    }

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


                    scenesTransition.NewFadeInFadeOut();
                    StartCoroutine(StartCounting());
                    break;
                }
            case "Wardrobe":
                {
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
                audioSource.PlayOneShot(audioClip[Random.Range(0,1)]);
                particle.transform.position = interactedItem.transform.position;
                particle.Play();
                ScenesSingleton.instance.ItemsCollected++;
                break;
            case "Bear":
                {
                    Bear bear = interactedItem.GetComponent<Bear>();
                    if (bearAlreadyInteracted == false)
                    {
                        roomMessagesManager.SetMessage(6, 5, () =>
                        {
                            if (_heartsManager != null)
                                _heartsManager.startSpawn = true;
                            roomMessagesManager.EnableAndStartTimer(true);
                        });
                        bearAlreadyInteracted = true;
                    }
                    else
                    {
                        if (bear.canHug)
                        {
                            particle.transform.position = interactedItem.transform.position;
                            particle.Play(true);
                            bear.MonsterToRandom();
                            StartCoroutine(bear.WaitToHugBear());
                        }
                    }
                    break;
                }
        }
    }

    public void FindCollectable(string name)
    {
        var obj = enviromentItens.transform.Find("Collectables").Find(name);
        GameObject collectable = enviromentItens.transform.Find("Collectables").Find(name).gameObject;
        collectable.SetActive(true);
        StartCoroutine(AnimateItem(collectable));
    }

    public void Update()
    {
        if(bearAlreadyInteracted && bearLastUseSecond <= 5)
            bearLastUseSecond += Time.deltaTime;
    }
    public IEnumerator AnimateItem(GameObject collectable)
    {
        collectable.GetComponent<Collider2D>().enabled = false;
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
        collectable.GetComponent<Collider2D>().enabled = true;
    }

    private IEnumerator StartCounting()
    {
        yield return new WaitForSeconds(2.7f);
        volume.profile = desiredProfile;
        for (int i = 0; i < this.collectiblesUI.transform.childCount; i++)
        {
            this.collectiblesUI.transform.GetChild(i).gameObject.SetActive(true);
        }
        roomMessagesManager.EnableAndStartTimer(true);
    }
}
