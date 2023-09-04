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

    public void LoadNewScene(int? i)
    {
        StartCoroutine(LoadScene(i));
    }

    public IEnumerator LoadScene(int? i)
    {
        anim.Play("FadeOut");
        yield return new WaitForSeconds(2f);
        i = i != null ? i : SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene((int)i);
    }

    public void NewFadeInFadeOut()
    {
        StartCoroutine(FadeInFadeOut());
    }

    public IEnumerator FadeInFadeOut()
    {
        anim.Play("FadeOut");
        yield return new WaitForSeconds(2f);
        anim.Play("FadeIn");
    }
}
