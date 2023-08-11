using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Application = UnityEngine.Device.Application;

public class SceneManager : MonoBehaviour
{
    [SerializeField] private GameObject settingsMenu; 
    public void PlayGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Level1");
        AudioManager.Instance.PlayTheme();
    }

    public void Settings()
    {
        if (settingsMenu.activeSelf)
        {
            settingsMenu.SetActive(false);
            Time.timeScale = 1;
        }
        else
        {
            settingsMenu.SetActive(true);
            Time.timeScale = 0;
        }
        
    }
    

    public void Exit()
    {
        Application.Quit();
    }
}
