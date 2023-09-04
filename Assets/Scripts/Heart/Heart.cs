using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Heart : MonoBehaviour
{

    private bool _destroy = false;

    void Start()
    {
        StartCoroutine(Disable());
    }

    void Update()
    {
        if (_destroy)
        {
            DestroyImmediate(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            ScenesSingleton.instance.HeartCount++;
            GameObject.Find("HeartCountText").GetComponent<TextMeshProUGUI>().text = $"x {ScenesSingleton.instance.HeartCount}";
            StopAllCoroutines();
            this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            _destroy = true;
        }
    }

    private IEnumerator Disable()
    {
        yield return new WaitForSeconds(7f);
        DestroyImmediate(this.gameObject);
    }
}
