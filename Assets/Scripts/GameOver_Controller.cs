using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;

public class GameOver_Controller : MonoBehaviour
{
    [SerializeField] Button restartButton;
    [SerializeField] Button mainMenuButton;

    private void Awake()
    {
        restartButton.onClick.AddListener(ReloadScene);
        mainMenuButton.onClick.AddListener(MainMenu);
    }

    //GameOver panel function is called at player controller
    public void GameOverPanel()
    {
        gameObject.SetActive(true);
 
    }

    //Reload Function
    void ReloadScene()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.buildIndex);
    }

    //Main menu function
    void MainMenu()
    {
        SceneManager.LoadScene(0);
    }


    /*void QuitGame()
    {
        //Application.Quit();
        EditorApplication.isPlaying = false;
    }
*/
}
