using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float rotationSpeed = 1f;
    public bool rotateClockWise = true;
    public float destroyX = 1f;
    public float scale = 1f;
    public Rigidbody2D rb;
    public bool enemy = false;

    public AudioClip[] clips;
    public AudioClip[] clipsWall;
    private AudioSource audioSource;
    private AudioSource audioSourceWallHit;

    private void Start()
    {
        transform.localScale = new Vector3(scale, scale);
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSourceWallHit = gameObject.AddComponent<AudioSource>();
    }

    private void FixedUpdate()
    {
        Move();
        Rotate();

        if (!enemy && transform.position.x > destroyX)
        {
            Destroy(gameObject);
        }
    }

    private void Move() 
    {
        rb.velocity = new Vector2(moveSpeed, 0f);
    }

    private void Rotate()
    {
        if (rotateClockWise)
        {
            rb.rotation -= rotationSpeed;
        }
        else
        {
            rb.rotation += rotationSpeed;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (enemy == true)
        {
            if (collision.gameObject.layer == 8)
            {
                PlayAudio("Death");
                Destroy(collision.gameObject);
                Destroy(gameObject);

            }
            else if (collision.gameObject.layer == 10)
            {
                PlayAudio("Death");
                Destroy(gameObject);
            }
        }
    }

    private void PlayAudio(string sound)
    {
        if (sound == "Death")
        {
            audioSource.volume = 0.1f;
            audioSource.PlayOneShot(clips[Random.Range(0, 2)]);
        }
        if (sound == "Hit")
        {
            audioSourceWallHit.volume = 0.1f;
            audioSourceWallHit.PlayOneShot(clipsWall[Random.Range(0, 2)]);
        }
    }
}
