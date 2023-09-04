using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartAvailable : MonoBehaviour
{
    public int heartCount;
    public Sprite heartNotAvailable;
    // Start is called before the first frame update
    void Start()
    {
        heartCount = 3;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void RemoveHeart()
    {
        var heart = this.gameObject.transform.Find("Heart" + heartCount);
        heart.GetComponent<Image>().sprite = heartNotAvailable;
        heartCount--;
        ScenesSingleton.instance.Health = heartCount;
    }
}
