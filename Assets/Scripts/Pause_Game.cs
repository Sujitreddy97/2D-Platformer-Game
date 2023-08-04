using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause_Game : MonoBehaviour
{
    
    public void PauseGamePanel()
    {
        Time.timeScale = 0;
        gameObject.SetActive(true);
    }

    public void mainMenu()
    {
        SceneManager.LoadScene(0);
        Sound_Manager.Instance.Play(SoundsName.ButtonClick);
    }


    public void ResumeGame()
    {
        Time.timeScale = 1;
        gameObject.SetActive(false);
        Sound_Manager.Instance.Play(SoundsName.ButtonClick);
    }
}
