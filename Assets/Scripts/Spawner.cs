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

    private void Update()
    {
        if (_projectileInstance == null) 
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
}
