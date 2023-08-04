using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver_Controller : MonoBehaviour
{
    [SerializeField] private Button restartButton;
    [SerializeField] private Button mainMenuButton;

    private void Awake()
    {
        restartButton.onClick.AddListener(ReloadScene);
        mainMenuButton.onClick.AddListener(MainMenu);
    }

    public void GameOverPanel()
    {
        gameObject.SetActive(true);
 
    }

    private void ReloadScene()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.buildIndex);
    }

    private void MainMenu()
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
