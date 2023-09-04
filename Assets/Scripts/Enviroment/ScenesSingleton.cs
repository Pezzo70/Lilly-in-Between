using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesSingleton : MonoBehaviour
{
    public static ScenesSingleton instance = null;
    public int HeartCount { get; set; }
    public int ItemsCollected { get; set; } = 0;
    public int Health { get; set; } = 3;

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
            HeartCount = 0;
            ItemsCollected = 0;
            Health = 3;
        }


        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            if (Health == 0)
            {
                EventManager.ChangeScene.Invoke(-1);
            }
        }


        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            if (ItemsCollected == 4)
            {
                EventManager.ChangeScene.Invoke(-1);
            }
        }
    }

}
