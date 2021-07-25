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

    public float minChangePatternTime = 5f;
    public float maxChangePatternTime = 10f;
    //x - spawnRate, y - moveSpeed, z - time from the last pattern
    public List<Vector3> patterns;

    [SerializeField] private GameObject _projectile = null;
    [SerializeField] private Arsenal _arsenal = null;
    private GameObject _projectileInstance = null;
    private Projectile _projectileInstanceScript = null;
    private bool touchedByPlayer = false;
    private bool spawned = false;
    private float respawnTimer;
    private float startTimer;
    private float patternTimer;
    private int nextPatternIndex = 1;
    private int currentPatternIndex = 0;

    public AudioClip[] clips;
    private AudioSource audioSource;


    private void Start()
    {
        if (enemy)
        {
            ApplyPattern();
        }

        if (automatic)
        {
            InvokeRepeating("Launch", spawnStartTime, spawnRate);
        }

        audioSource = gameObject.AddComponent<AudioSource>();
    }

    private void Update()
    {
        if (enemy && patterns.Count > 0)
        {
            patternTimer += Time.deltaTime;

            if ((patternTimer >= patterns[nextPatternIndex].z) && (nextPatternIndex > currentPatternIndex))
            {
                currentPatternIndex = nextPatternIndex;

                ApplyPattern();

                if (currentPatternIndex < (patterns.Count - 1))
                {
                    nextPatternIndex++;
                }
            }
        }

        if (!enemy && !automatic)
        {
            ProcessInput();
        }

        if (enemy)
        {
            startTimer += Time.deltaTime;

            if (startTimer >= patterns[currentPatternIndex].z && !spawned)
            {
                Invoke("Launch", 0f);
                spawned = true;
            }

            if (spawned) 
            {
                respawnTimer += Time.deltaTime;

                if (respawnTimer >= patterns[currentPatternIndex].x)
                {
                    respawnTimer -= spawnRate;
                    Invoke("Launch", 0f);
                }
            }
        }
    }

    private void ApplyPattern()
    {
        Vector3 pattern = patterns[currentPatternIndex];

        spawnRate = pattern.x;
        moveSpeed = pattern.y;
    }

    private void ProcessInput()
    {
        if (Input.GetKeyDown(KeyCode.Space) && touchedByPlayer && !(enemy || automatic) && _arsenal.weaponCount > 0)
        {
            _arsenal.UseWeapon(1);
            Launch();
            PlayAudio("Throw");
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
    }

    private void PlayAudio(string sound)
    {
        if (sound == "Throw")
        {
            audioSource.volume = 0.2f;
            audioSource.PlayOneShot(clips[Random.Range(0, 2)]);
        }
    }
}
