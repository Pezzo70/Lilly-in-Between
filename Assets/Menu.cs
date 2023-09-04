using System.Collections;
using UnityEngine;

public class Menu : MonoBehaviour
{

    public GameObject button;

    public void Start()
    {
        StartCoroutine(Wait());
    }

    public void OnClickOnButton()
    {
        EventManager.ChangeScene.Invoke(-1);
        button.SetActive(false);
    }

    public IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.5f);
        button.SetActive(true);
    }

}
