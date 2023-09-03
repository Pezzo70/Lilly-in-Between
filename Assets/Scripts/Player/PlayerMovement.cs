using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float _speed;

    private Animator _animator;
    private Vector2 _movementInput;

    private void Awake()
    {
        _animator = this.gameObject.GetComponent<Animator>();
    }

    private void Update()
    {
        this.transform.position += new Vector3(_movementInput.x, _movementInput.y, 0) * _speed * Time.deltaTime;
        SetAnimation();
    }

    private void OnMove(InputValue inputValue)
    {
        _movementInput = inputValue.Get<Vector2>();
    }

    private void SetAnimation()
    {
        foreach (var param in _animator.parameters) _animator.SetBool(param.name, false);

        if (this._movementInput.x != 0)
        {
            if (this._movementInput.x > 0)
                _animator.SetBool("MoveR", true);
            else if (this._movementInput.x < 0)
                _animator.SetBool("MoveL", true);
        }
        else if (this._movementInput.y != 0)
        {
            if (this._movementInput.y > 0)
                _animator.SetBool("MoveU", true);
            else if (this._movementInput.y < 0)
                _animator.SetBool("MoveB", true);
        }
        else
            _animator.Play("Idle");

    }
}
