using UnityEngine;
using UnityEngine.UI;

public class Arsenal : MonoBehaviour
{
    [SerializeField] private Text weaponText;
    [SerializeField] private Text timeText;

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
