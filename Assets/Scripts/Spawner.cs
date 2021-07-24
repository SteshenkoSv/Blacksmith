using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _projectile = null;
    [SerializeField] private Text _text = null;
    private GameObject _projectileInstance = null;


    private void Update()
    {
        if (_projectileInstance == null) 
        {
            _projectileInstance = Instantiate(_projectile, transform);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _text.color = Color.green;
            _text.text = "Кузнецу пиздец";
        }
    }
}
