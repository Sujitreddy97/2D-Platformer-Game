using UnityEngine;

public class Enemy_Controller : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    
    [SerializeField] private GameObject groundDetect;

    [SerializeField] private float rayDistance;

    private int movingRight = 1;

    void Update()
    {
        EnemyHorizontalMovemet();
    }


    private void EnemyHorizontalMovemet()
    {
        transform.Translate(movingRight * Vector2.right * speed * Time.deltaTime);

        RaycastHit2D hit = Physics2D.Raycast(groundDetect.transform.position, Vector2.down, rayDistance);
        
        if(!hit)
        {
            transform.localScale = new Vector2(-1 * transform.localScale.x, transform.localScale.y);
            movingRight = movingRight * -1;
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        Player_Controller playerController = collision.gameObject.GetComponent<Player_Controller>();

        if (playerController != null)
        {

           playerController.DecreaseLife();
           if(playerController.isAlive == false)
            {
                speed = 0;
            }
        }
    }

}
