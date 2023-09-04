using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesSingleton : MonoBehaviour
{
    public static ScenesSingleton instance = null;

    public int ItemsCollected { get; set; } = 0;

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

    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            if (ItemsCollected == 4)
            {
                EventManager.ChangeScene.Invoke();
            }
        }
    }

}
