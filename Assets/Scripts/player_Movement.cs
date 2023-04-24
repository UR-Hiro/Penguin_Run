using UnityEngine;


public class player_Movement : MonoBehaviour
{
    [SerializeField] private float jump = 10f;
    [SerializeField] private Rigidbody2D rb2d; 

    [SerializeField] private Animator animator;

    [SerializeField] private float rayCastDist = 5f;

    [SerializeField] private LayerMask rayCastMask;

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

        RaycastHit2D hit2D = Physics2D.Raycast(transform.position,Vector2.down, rayCastDist, rayCastMask);
        if(hit2D){
            isGrounded = true;
            Debug.DrawLine(transform.position, ((Vector2)transform.position + (Vector2.down * rayCastDist)), Color.green);
        }

        else{
            isGrounded = false;
            Debug.DrawLine(transform.position, ((Vector2)transform.position + (Vector2.down * rayCastDist)), Color.red);
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

        if(!Input.GetKey(KeyCode.UpArrow) && !Input.GetKey(KeyCode.Space)) return;

        isGrounded = false;
        rb2d.AddForce(Vector2.up * jump, ForceMode2D.Impulse);
    
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
