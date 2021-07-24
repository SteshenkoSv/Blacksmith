using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float scale = 1f;
    public float moveSpeed = 1f;
    public float rotationSpeed = 1f;
    public bool rotateClockWise = true;
    public float destroyY = 1f;

    [SerializeField] private GameObject _projectile = null;
    private GameObject _projectileInstance = null;
    private Projectile _projectileInstanceScript = null;
    private bool touchedByPlayer = false;

    private void Update()
    {
        ProcessInput();
        Debug.Log(touchedByPlayer);
    }

    private void ProcessInput()
    {
        if (Input.GetKeyDown(KeyCode.Space) && touchedByPlayer)
        {
            _projectileInstance = Instantiate(_projectile, transform);
            _projectileInstanceScript = _projectileInstance.GetComponent<Projectile>();
            _projectileInstanceScript.scale = scale;
            _projectileInstanceScript.moveSpeed = moveSpeed;
            _projectileInstanceScript.rotationSpeed = rotationSpeed;
            _projectileInstanceScript.rotateClockWise = rotateClockWise;
            _projectileInstanceScript.destroyY = destroyY;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            touchedByPlayer = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            touchedByPlayer = false;
        }
    }
}
