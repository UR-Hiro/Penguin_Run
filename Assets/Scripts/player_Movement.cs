using UnityEngine;


public class player_Movement : MonoBehaviour
{
    [SerializeField] private float jump = 10f;
    [SerializeField] private Rigidbody2D rb2d; 

    [SerializeField] private Animator animator;

    private bool isGrounded;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();  
        if(animator == null) animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (isGrounded == false){
            animator.SetBool("isjumping",true);
        }
        
        if (isGrounded == true){
            animator.SetBool("isjumping",false);
        }
    }
    void FixedUpdate()
    {
        PlayerMovement();
    }

    //movement
    private void PlayerMovement()
{
        if(!isGrounded)return;

        if(Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space)){
            isGrounded = false;
            rb2d.AddForce(Vector2.up * jump, ForceMode2D.Impulse);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision2D){
        if (collision2D.gameObject.CompareTag("obstacle"))
        {
            Debug.Log("Game Over!");
            GameEvent.current.GameOver();
        }
    }

        private void OnTriggerEnter2D(Collider2D collider2D){
        if(collider2D.CompareTag("ground")){
            isGrounded = true;
        }
        if(collider2D.CompareTag("scorecollider"))GameEvent.current.ScoreCollided();
    }

}
