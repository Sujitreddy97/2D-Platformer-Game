using UnityEngine;
using UnityEngine.UI;


public class Player_Controller : MonoBehaviour
{
    [SerializeField] private Pause_Game pauseGame_Controller;

    [SerializeField] private GameOver_Controller gameOver_Controller;

    [SerializeField] private Animator animator;

    [SerializeField] private Score_Manager scoreManager;

    [SerializeField] private float speed;

    [SerializeField] private float jumpForce;

    [SerializeField] private Transform startPosition;

    [SerializeField] private Camera mainCamera;

    [SerializeField] private Image[] hearts;

    [SerializeField] private float delayPlayerInvoke = 0.25f;

    [SerializeField] private float delayGameOverPanel = 0.9f;

    [SerializeField] private ParticleSystem deathParticleEffect;

    [SerializeField] private ParticleSystem spawnParticleEffect;


    private bool isGrounded;

    private Rigidbody2D rb;

    private int lives = 3;

    public bool isAlive;

    private bool isPaused = true;

    private void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }



    void Update()
    {

        PlayerMovement();
        PauseMenuUI();
    }


    public void PickKey()
    {
        scoreManager.IncreaseScore(10);
        Sound_Manager.Instance.Play(SoundsName.KeyPickup);
    }

    private void PauseMenuUI()
    {
        
        if(Input.GetKeyDown(KeyCode.Escape) && isAlive)
        {
            if(!isPaused)
            {
                pauseGame_Controller.PauseGamePanel();
                isPaused = true;
                Sound_Manager.Instance.Play(SoundsName.ButtonClick);
            }
            else if(isPaused)
            {
                pauseGame_Controller.ResumeGame();
                isPaused = false;
                Sound_Manager.Instance.Play(SoundsName.ButtonClick);
            }
        }
    }


    private void PlayerMovement()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        HorizontalMove(horizontal);

        float vertical = Input.GetAxisRaw("Jump");
        Jump(vertical);

        Crouch();
    }


    private void HorizontalMove(float horizontal)
    {
        Vector3 position = transform.position;
        position.x += horizontal * speed * Time.deltaTime;
        transform.position = position;

        animator.SetFloat(Constants.animatior_Speed, Mathf.Abs(horizontal));

        Vector3 scale = transform.localScale;

        if (horizontal < 0)
        {
            scale.x = -1f * Mathf.Abs(scale.x);
            //Sound_Manager.Instance.Play(SoundsName.PlayerMove);
        }
        else if (horizontal > 0) 
        {
            scale.x = Mathf.Abs(scale.x);
            //Sound_Manager.Instance.Play(SoundsName.PlayerMove);
        }
        
        transform.localScale = scale;
    }


    private void Jump(float vertical)
    {
        if (vertical > 0 && isGrounded)
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            animator.SetTrigger(Constants.animatior_Jump);
            isGrounded = false;
            Sound_Manager.Instance.Play(SoundsName.PlayerJump);
        }

    }


    private void Crouch()
    {

        if (Input.GetKeyDown(KeyCode.LeftControl) && isGrounded)
        {
  
            animator.SetBool(Constants.animatior_Crouch, true);
        }
        else if (Input.GetKeyUp(KeyCode.LeftControl))
        {
       
            animator.SetBool(Constants.animatior_Crouch, false);
        }

    }

    public void DecreaseLife()
    {
        lives--;
        HandleHealthUI();

        if (lives <= 0)
        {
            playerDeath();
        }
        else
        {
            Invoke(nameof(PlayerInvoke), delayPlayerInvoke);
            spawnParticleEffect.Play();
        }
    }


    private void PlayerInvoke()
    {
        transform.position = startPosition.position;
    }



    public void playerDeath()
    {
        isAlive = false;
        
        animator.SetTrigger(Constants.animatior_Death);
        Invoke(nameof(DelayGameoverPanel), delayGameOverPanel);
        Sound_Manager.Instance.Play(SoundsName.PlayerDeath);
        this.enabled = false;

        deathParticleEffect.Play();
    }

    private void DelayGameoverPanel()
    {
        
        gameOver_Controller.GameOverPanel();
    }


    private void HandleHealthUI()
    {
        for(int i = 0; i < hearts.Length; i++)
        {
            hearts[i].color = i < lives ? Color.red : Color.black;
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(Constants.Ground_Tag))
        {
            isGrounded = true;
            //Debug.Log("Grounded");
        }
    }


    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(Constants.Ground_Tag))
        {
            //Debug.Log("not Grounded");
            isGrounded = false;
        }
    }
}
