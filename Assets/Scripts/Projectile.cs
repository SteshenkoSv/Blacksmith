using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 1f;
    public float rotationRate;
    public bool rotationDirection;
    public Rigidbody2D rb;

    private void FixedUpdate()
    {
        Move();
        if (transform.position.y < -7.5f)
        {
            Destroy(gameObject);
        }
    }

    private void Move() 
    {
        rb.velocity = new Vector2(0f, -1f * speed);
    }
}
