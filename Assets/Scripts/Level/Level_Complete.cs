using UnityEngine;
using UnityEngine.SceneManagement;

public class Level_Complete : MonoBehaviour
{
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<Player_Controller>() !=null)
        {
                Level_Manager.Instance.SetLevelComplete();
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                Sound_Manager.Instance.Play(SoundsName.LevelComplete);       
        }
    }
}
