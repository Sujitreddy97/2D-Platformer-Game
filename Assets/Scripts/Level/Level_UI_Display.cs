using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Level_UI_Display : MonoBehaviour
{
    private TMP_Text levelDisplay;
    private int getIndex;

    private void Awake()
    {
        levelDisplay = GetComponent<TMP_Text>();
        getIndex = SceneManager.GetActiveScene().buildIndex;
    }


    private void Start()
    {
        levelDisplay.text = "Level - " + getIndex;
    }


}
