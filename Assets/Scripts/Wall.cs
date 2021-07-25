using UnityEngine;
using UnityEngine.UI;

public class Wall : MonoBehaviour
{
    public int hp = 10;
    public Text text = null;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            hp -= 1;
            text.text = hp.ToString();
        }
    }
}
