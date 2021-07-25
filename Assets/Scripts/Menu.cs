using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject mainPanel;
    public GameObject infoPanel;

    public void PlayButtonClick() 
    {
        SceneManager.LoadScene("Main");
    }

    public void InfoButtonClick()
    {
        mainPanel.SetActive(false);
        infoPanel.SetActive(true);
    }
    public void BackButtonClick()
    {
        infoPanel.SetActive(false);
        mainPanel.SetActive(true);
    }
    public void ToMenuButtonClick()
    {
        SceneManager.LoadScene("Menu");
    }

    public void ExitButtonClick()
    {
        Application.Quit();
    }
}
