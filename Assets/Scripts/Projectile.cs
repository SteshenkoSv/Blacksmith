using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float rotationSpeed = 1f;
    public bool rotateClockWise = true;
    public float destroyY = 1f;
    public float scale = 1f;
    public Rigidbody2D rb;

    private void Start()
    {
        transform.localScale = new Vector3(scale, scale);
    }

    private void FixedUpdate()
    {
        Move();
        Rotate();
        if (transform.position.y < destroyY)
        {
            Destroy(gameObject);
        }
    }

    private void Move() 
    {
        rb.velocity = new Vector2(0f, moveSpeed);
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
}
