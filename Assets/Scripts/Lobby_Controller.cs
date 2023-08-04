using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class Lobby_Controller : MonoBehaviour
{
    [SerializeField] private Button playButton;
    [SerializeField] private Button quitButton;
    [SerializeField] private GameObject Level_Selection;

    private void Awake()
    {
        playButton.onClick.AddListener(PlayGame);
        quitButton.onClick.AddListener(QuitGame);
    }


    private void PlayGame()
    {
        Level_Selection.SetActive(true);
        Sound_Manager.Instance.Play(SoundsName.ButtonClick);
    }

    private void QuitGame()
    {
        //Application.Quit();
        EditorApplication.isPlaying = false;
        Sound_Manager.Instance.Play(SoundsName.ButtonClick);
    }
}
