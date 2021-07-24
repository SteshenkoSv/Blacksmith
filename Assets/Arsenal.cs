using UnityEngine;
using UnityEngine.UI;

public class Arsenal : MonoBehaviour
{
    [SerializeField] private Text weaponText;
    [SerializeField] private Text timeText;

    public int weaponCount = 0;
    public int time = 0;

    private float timer;

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 1f)
        {
            timer -= 1f;
            time += 1;
            weaponCount += time;
            UpdateArsenalValues();
        }
    }

    public void UpdateArsenalValues()
    {
        timeText.text = time.ToString();
        weaponText.text = weaponCount.ToString();
    }
}
