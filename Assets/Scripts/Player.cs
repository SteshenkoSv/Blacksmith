using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 1f;
    [SerializeField] private Rigidbody2D _rb = null;
    private Vector2 _moveDirection;
    private bool _inputLocked = false;

    public AudioClip[] clips;
    private float timeRemaining = 0.4f;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
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

        if (_moveDirection.x != 0 || _moveDirection.y != 0)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                PlayAudio("Step");
                timeRemaining = 0.4f;
            }
        } 
    }

    private void PlayAudio(string sound)
    {
        if (sound == "Step")
        {
            audioSource.volume = 0.08f;
            audioSource.PlayOneShot(clips[Random.Range(0, 3)]);
        }
    }
}
