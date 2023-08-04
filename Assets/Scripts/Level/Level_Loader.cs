using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class Level_Loader : MonoBehaviour
{
    private Button button;

    [SerializeField] private int LevelIndex;


    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);
    }

    private void Start()
    {
        if (Level_Manager.Instance.GetLevelStatus(LevelIndex) == LevelStatus.Locked)
            GetComponent<Image>().color = Color.grey;
        else
            GetComponent<Image>().color = Color.white;
    }


    private void OnClick()
    {
        LevelStatus levelStatus = Level_Manager.Instance.GetLevelStatus(LevelIndex);

        switch (levelStatus)
        {
            case LevelStatus.Locked:
                Debug.Log("Can't play this level till you unlock");
                break;

            case LevelStatus.Unlocked:
                SceneManager.LoadScene(LevelIndex);
                break;

            case LevelStatus.Completed:
                SceneManager.LoadScene(LevelIndex);
                break;

        }
                
    }
}
