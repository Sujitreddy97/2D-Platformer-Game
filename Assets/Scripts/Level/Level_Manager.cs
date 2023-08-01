using UnityEngine;
using UnityEngine.SceneManagement;

public class Level_Manager : MonoBehaviour
{
    private static Level_Manager instance;
    public static Level_Manager Instance { get { return instance; } }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        if (GetLevelStatus("Level_01") == LevelStatus.Locked)
        {
            SetLevelStatus("Level_01", LevelStatus.Unlocked);
        }
    }

    public void LoadAnyLevel(int levelNumber)
    {
        // Check if the level is unlocked.
        LevelStatus levelStatus = GetLevelStatus(levelNumber.ToString());
        if (levelStatus == LevelStatus.Unlocked)
        {
            // Load the level.
            SceneManager.LoadScene(levelNumber);
        }
    }



    //Get Level Status Function
    public LevelStatus GetLevelStatus(string level)
    {
        LevelStatus levelStatus = (LevelStatus)PlayerPrefs.GetInt(level, 0);
        return levelStatus;
    }

    //Set Level Status Function
    public void SetLevelStatus(string level, LevelStatus levelStatus)
    {
        PlayerPrefs.SetInt(level, (int)levelStatus);
    }
}
