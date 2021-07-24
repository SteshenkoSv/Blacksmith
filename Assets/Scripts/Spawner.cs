using UnityEngine;
using System.Collections;
using System.Collections.Generic;

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
    public bool changePatternActive = false;
    public float minChangePatternTime = 5f;
    public float maxChangePatternTime = 10f;
    //x - spawnRate, y - moveSpeed
    public List<Vector2> patterns;

    [SerializeField] private GameObject _projectile = null;
    [SerializeField] private Arsenal _arsenal = null;
    private GameObject _projectileInstance = null;
    private Projectile _projectileInstanceScript = null;
    private bool touchedByPlayer = false;
    private bool spawned = false;
    private float respawnTimer;
    private float startTimer;
    private float patternTimer;
    private float changePatternTime;

    private void Start()
    {
        if (enemy && changePatternActive && patterns.Count > 0) 
        {
            changePatternTime = Random.Range(minChangePatternTime, maxChangePatternTime);
            Debug.Log("next pattern in: " + changePatternTime);
        }

        if (automatic)
        {
            InvokeRepeating("Launch", spawnStartTime, spawnRate);
        }
    }

    private void Update()
    {
        if (enemy && changePatternActive && patterns.Count > 0)
        {
            patternTimer += Time.deltaTime;

            if (patternTimer >= changePatternTime)
            {
                patternTimer -= changePatternTime;

                changePatternTime = Random.Range(minChangePatternTime, maxChangePatternTime);
                Debug.Log("next pattern in: "+changePatternTime);
                ChangePattern();
            }
        }

        if (!enemy && !automatic)
        {
            ProcessInput();
        }

        if (enemy)
        {
            startTimer += Time.deltaTime;

            if (startTimer >= spawnStartTime && !spawned)
            {
                Invoke("Launch", 0f);
                spawned = true;
            }

            if (spawned) 
            {
                respawnTimer += Time.deltaTime;

                if (respawnTimer >= spawnRate)
                {
                    respawnTimer -= spawnRate;
                    Invoke("Launch", 0f);
                }
            }

        }
    }

    private void ChangePattern()
    {
        int patternIndex = Random.Range(0, patterns.Count);

        Vector2 pattern = patterns[patternIndex];

        spawnRate = pattern.x;
        moveSpeed = pattern.y;

        Debug.Log("new pattern: " + spawnRate + ", " + moveSpeed);
    }

    private void ProcessInput()
    {
        if (Input.GetKeyDown(KeyCode.Space) && touchedByPlayer && !(enemy || automatic) && _arsenal.weaponCount > 0)
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
