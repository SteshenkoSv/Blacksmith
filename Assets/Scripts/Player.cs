using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float moveSpeed = 1f;
    [SerializeField] private SpriteRenderer _renderer = null;
    [SerializeField] private Rigidbody2D _rb = null;
    private Vector2 _moveDirection;
    private bool _inputLocked = false;

    private void Update()
    {
        ProcessInput();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void ProcessInput() 
    {
        if (!_inputLocked)
        {
            float moveX = Input.GetAxisRaw("Horizontal");
            float moveY = Input.GetAxisRaw("Vertical");

            _moveDirection = new Vector2(moveX, moveY).normalized;
        }
        else
        {
            _moveDirection = Vector2.zero;
        }
    }

    private void Move() 
    {
        _rb.velocity = new Vector2(_moveDirection.x * moveSpeed, _moveDirection.y * moveSpeed);
    }
}
