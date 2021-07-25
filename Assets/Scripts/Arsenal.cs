using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Arsenal : MonoBehaviour
{
    [SerializeField] private Text weaponText;
    [SerializeField] private Text timeText;
    [SerializeField] private Wall wall;

    public int weaponCount = 0;
    public int weaponGiveawayRate = 1;
    public int weaponGiveawayCount = 1;
    public int time = 0;

    private float timer;
    private float weaponTimer;

    private void Start()
    {
        timeText.text = time.ToString();
        weaponText.text = weaponCount.ToString();
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 1f)
        {
            timer -= 1f;
            time += 1;
            timeText.text = time.ToString();
        }

        if (time >= 61 && wall.hp > 0) 
        {
            SceneManager.LoadScene("WinScreen");
        }

        weaponTimer += Time.deltaTime;

        if (weaponTimer >= weaponGiveawayRate)
        {
            weaponTimer -= weaponGiveawayRate;
            AddWeapon(weaponGiveawayCount);
        }
    }
    public void UseWeapon(int count) 
    {
        weaponCount -= count;
        weaponText.text = weaponCount.ToString();
    }

    public void AddWeapon(int count)
    {
        weaponCount += count;
        weaponText.text = weaponCount.ToString();
    }
}
