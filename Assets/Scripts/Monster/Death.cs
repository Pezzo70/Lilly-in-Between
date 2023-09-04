using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Death : MonoBehaviour
{

    public Volume volume;
    public VolumeProfile deathProfile;
    public VolumeProfile previousProfile;
    public AudioSource audioSource;
    public AudioClip[] audioClips;
    public GameObject death;
    private Coroutine coroutine = null;
    void Start()
    {

    }

    void Update()
    {

    }

    public void Trigger()
    {
        if (coroutine == null)
        {
            ShowDeath();
            coroutine = StartCoroutine(WaitAndClear());
        }
    }

    private IEnumerator WaitAndClear()
    {
        yield return new WaitForSeconds(2f);
        death.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        volume.profile = previousProfile;
        coroutine = null;
    }

    private void ShowDeath()
    {
        death.gameObject.GetComponent<SpriteRenderer>().enabled = true;
        volume.profile = deathProfile;
        audioSource.PlayOneShot(audioClips[Random.Range(0, audioClips.Length - 1)]);
        StartCoroutine(WaitAndClear());
    }
}
