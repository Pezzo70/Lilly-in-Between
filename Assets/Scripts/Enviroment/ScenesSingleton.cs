using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenesSingleton : MonoBehaviour
{
    public static ScenesSingleton instance = null;
    public int HeartCount { get; set; }

    void Awake()
    {
        if (instance != null)
        {
            DestroyImmediate(this.gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }
}
