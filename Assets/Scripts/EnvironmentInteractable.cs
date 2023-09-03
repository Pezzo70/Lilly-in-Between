using UnityEngine;

public class EnvironmentInteractable : MonoBehaviour
{

    public bool IsOneTimeInteractable = false;

    private BoxCollider2D _boxCollider2D;
    public GameObject UiElement;

    private void Awake()
    {
        _boxCollider2D = this.GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (UiElement != null)
            UiElement.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (UiElement != null)
            UiElement.SetActive(false);
    }

    private void DeactivateBoxCollider() => _boxCollider2D.enabled = false;

}
