using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Wall : MonoBehaviour
{
    public int hp = 10;
    public Text text = null;

    private void Update()
    {
        if (hp <= 0) 
        {
            SceneManager.LoadScene("LoseScreen");
        }        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            hp -= 1;
            text.text = hp.ToString();
        }
    }
}
