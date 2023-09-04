using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CollectableUI : MonoBehaviour
{
    public GameObject collectable;

    private Sprite collectableSprite;    
    private bool hasCollected;

    // Start is called before the first frame update
    void Start()
    { 
        collectableSprite = collectable.GetComponent<SpriteRenderer>().sprite.CloneViaSerialization();
    }

    private void Update()
    {
        if (!hasCollected && collectable == null)
        {
            hasCollected = true;
            this.GetComponent<Image>().sprite = collectableSprite;
            StartCoroutine(AnimateUI());
        }
    }

    private IEnumerator AnimateUI()
    {
        Vector2 initialPosition = this.transform.position;
        Vector2 vector = initialPosition;
        float seconds = 0.06f;
        float movement = 0.50f;
        do
        {
            this.transform.position = vector;
            yield return new WaitForSeconds(seconds);
            vector.y += movement;
        } while (vector.y <= initialPosition.y + 0.8);

        do
        {
            this.transform.position = vector;
            yield return new WaitForSeconds(seconds);
            vector.y -= movement;
        } while (vector.y >= initialPosition.y - 0.8);

        do
        {
            this.transform.position = vector;
            yield return new WaitForSeconds(seconds);
            vector.y += movement;
        } while (vector.y <= initialPosition.y);
    }

}
