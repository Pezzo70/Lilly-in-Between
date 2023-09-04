using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenesSingleton : MonoBehaviour
{
    private static ScenesSingleton instance = null;

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
