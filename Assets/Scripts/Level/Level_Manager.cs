using UnityEngine;
using UnityEngine.SceneManagement;

public class Level_Manager : MonoBehaviour
{
    private static Level_Manager instance;
    private int defaultIndex = 0;
    private int firstLevelIndex = 1;
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
        if (GetLevelStatus(firstLevelIndex) == LevelStatus.Locked)
        {
            SetLevelStatus(firstLevelIndex, LevelStatus.Unlocked);
        }
    }


    public void SetLevelStatus(int level, LevelStatus levelStatus)
    {
        PlayerPrefs.SetInt(level.ToString(), (int)levelStatus);
    }


    public LevelStatus GetLevelStatus(int level)
    {
        LevelStatus levelStatus = (LevelStatus)PlayerPrefs.GetInt(level.ToString(),defaultIndex);
        return levelStatus;
    }

    public void SetLevelComplete()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SetLevelStatus(currentScene, LevelStatus.Completed);

        int nextScene = currentScene + 1;

        if(GetLevelStatus(nextScene)==LevelStatus.Locked)
        {
            SetLevelStatus(nextScene, LevelStatus.Unlocked);
        }
    }
   
}
