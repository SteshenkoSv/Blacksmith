using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float moveSpeed = 1f;
    public bool inTimerZone;
    public bool stunned = false;
    [SerializeField] private SpriteRenderer _renderer = null;
    [SerializeField] private Rigidbody2D _rb = null;
    [SerializeField] private Text _text = null;
    private Vector2 _moveDirection;
    private bool _inputLocked = false;

    private void Start()
    {
        _text.color = Color.cyan;
        _text.text = "";
    }

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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Projectile")
        {
            if (inTimerZone && !stunned)
            {
                StartCoroutine("Stun");
            }
        }
    }

    private IEnumerator Stun() 
    {
        _inputLocked = true;
        stunned = true;
        _renderer.color = new Color(_renderer.color.r, _renderer.color.g, _renderer.color.b, 0.5f);
        _text.color = Color.yellow;
        _text.text = "Stunned";
        yield return new WaitForSeconds(2f);
        _inputLocked = false;
        _text.color = Color.cyan;
        _text.text = "Invulnerable";
        yield return new WaitForSeconds(1f);
        stunned = false;
        _renderer.color = new Color(_renderer.color.r, _renderer.color.g, _renderer.color.b, 1f);
        _text.color = Color.cyan;
        _text.text = "";
    }
}
