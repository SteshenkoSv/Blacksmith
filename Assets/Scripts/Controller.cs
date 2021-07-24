using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{
    public float moveSpeed = 1f;

    [SerializeField] private Rigidbody2D _rb = null;
    [SerializeField] private Text _text = null;
    private Vector2 _moveDirection;

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
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        _moveDirection = new Vector2(moveX, moveY).normalized;
    }

    private void Move() 
    {
        _rb.velocity = new Vector2(_moveDirection.x * moveSpeed, _moveDirection.y * moveSpeed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Projectile")
        {
            _text.color = Color.red;
            _text.text = "Тебе пиздец";
        }
    }
}
