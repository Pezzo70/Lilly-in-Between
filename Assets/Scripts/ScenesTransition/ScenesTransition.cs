using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesTransition : MonoBehaviour
{
    public Animator anim;

    void Start()
    {

    }

    void Update()
    {

    }

    public void OnEnable()
    {
        EventManager.ChangeScene += LoadNewScene;
    }

    public void OnDisable()
    {
        EventManager.ChangeScene -= LoadNewScene;
    }

    public void LoadNewScene()
    {
        StartCoroutine(LoadScene());
    }

    public IEnumerator LoadScene()
    {
        anim.Play("FadeOut");
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
