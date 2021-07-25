using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 1f;
    [SerializeField] private Rigidbody2D _rb = null;
    private Vector2 _moveDirection;
    private bool _inputLocked = false;

    private float distanceWalked = 0;

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

        if (distanceWalked <= 5)
        {
            PlayAudio("Step");
            distanceWalked = 0;
        }
        else
        {
            distanceWalked += Mathf.Abs(_rb.velocity.magnitude - distanceWalked);
        }
    }

    private void PlayAudio(string sound)
    {
        if (sound == "Step")
        {

        }
    }
}
