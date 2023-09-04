using UnityEngine;

public class EnvironmentInteractable : MonoBehaviour
{

    public bool IsOneTimeInteractable = false;
    public GameObject _uiElement;

    private void Awake()
    {
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (_uiElement != null)
            _uiElement.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (_uiElement != null)
            _uiElement.SetActive(false);
    }

}
