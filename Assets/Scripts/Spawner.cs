using UnityEngine;

public class Spawner : MonoBehaviour
{
    public bool enemy = false;
    public bool automatic = false;
    public float scale = 1f;
    public float moveSpeed = 1f;
    public float rotationSpeed = 1f;
    public bool rotateClockWise = true;
    public float destroyX = 1f;
    public float spawnStartTime = 1f;
    public float spawnRate = 1f;

    [SerializeField] private GameObject _projectile = null;
    [SerializeField] private Arsenal _arsenal = null;
    private GameObject _projectileInstance = null;
    private Projectile _projectileInstanceScript = null;
    private bool touchedByPlayer = false;

    private void Start()
    {
        if(enemy || automatic)
        {
            InvokeRepeating("Launch", spawnStartTime, spawnRate);
        }
    }

    private void Update()
    {
        if (!enemy && !automatic)
        {
            ProcessInput();
        }
    }

    private void ProcessInput()
    {
        if (Input.GetKeyDown(KeyCode.Space) && touchedByPlayer && !(enemy || automatic))
        {
            Launch();
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

    private void Launch() 
    {
        _projectileInstance = Instantiate(_projectile, transform);
        _projectileInstanceScript = _projectileInstance.GetComponent<Projectile>();
        _projectileInstanceScript.scale = scale;
        _projectileInstanceScript.moveSpeed = moveSpeed;
        _projectileInstanceScript.rotationSpeed = rotationSpeed;
        _projectileInstanceScript.rotateClockWise = rotateClockWise;
        _projectileInstanceScript.destroyX = destroyX;
        _projectileInstanceScript.enemy = enemy;

        if (!enemy)
        {
            _arsenal.weaponCount -= 1;
            _arsenal.UpdateArsenalValues();
        }
    }
}
