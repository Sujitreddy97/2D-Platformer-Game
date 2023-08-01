using UnityEngine;
using UnityEngine.SceneManagement;



public class LevelOver_Controller : MonoBehaviour
{
 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<Player_Controller>() !=null)
        {
            // Unlock the next level.
            Level_Manager.Instance.SetLevelStatus(GetNextLevelNumber().ToString(), LevelStatus.Unlocked);

            // Load the next level.
            Level_Manager.Instance.LoadAnyLevel(GetNextLevelNumber());

        }
    }
    // Get the number of the next level.
    private int GetNextLevelNumber()
    {
        int currentLevelNumber = SceneManager.GetActiveScene().buildIndex;
        return currentLevelNumber + 1;
    }


}
