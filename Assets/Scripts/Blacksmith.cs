using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Blacksmith : MonoBehaviour
{
    [SerializeField] private Text _text = null;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine("Killed");
        }
    }

    private IEnumerator Killed()
    {
        _text.color = Color.green;
        _text.text = "Blacksmith eats ass";
        yield return new WaitForSeconds(1f);
        _text.text = "";
    }
}
