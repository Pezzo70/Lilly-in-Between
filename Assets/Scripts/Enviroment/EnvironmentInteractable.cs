using UnityEngine;

public class EnvironmentInteractable : MonoBehaviour
{
    private bool interactEnabled;
    public bool IsOneTimeInteractable = false;
    public GameObject _uiElement;
    public RoomMessagesManager roomMessagesManager;

    private void Start()
    {
        interactEnabled = true;
    }
    private void Awake()
    {
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (_uiElement != null && interactEnabled)
            _uiElement.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (_uiElement != null)
            _uiElement.SetActive(false);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (_uiElement != null && interactEnabled && roomMessagesManager.coroutine == null)
            _uiElement.SetActive(true);
        else
            _uiElement.SetActive(false);
    }

    public void SetInteractEnabled(bool enabled) 
    {
        interactEnabled = enabled;
    }
}
