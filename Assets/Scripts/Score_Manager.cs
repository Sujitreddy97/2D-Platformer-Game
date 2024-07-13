using UnityEngine;
using TMPro;


public class Score_Manager : MonoBehaviour
{

    private TMP_Text scoreText;
    private int score = 0;
    private void Awake()
    {
        scoreText = GetComponent<TMP_Text>();
    }


    private void Start()
    {
        RefreshUI();
    }

    public void IncreaseScore(int increament)
    {
        score += increament;
        RefreshUI();
    }

    private void RefreshUI()
    {
        scoreText.text = "Score: " + score; 
    }

}
