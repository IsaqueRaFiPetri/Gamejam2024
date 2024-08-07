using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D body;
    float horizontal, jump;

    [Header("Variaveis de Força")]
    public float moveSpeed;
    public float jumpStregth;
    float climbForce;

    [Header("Nome dos Input")]
    [SerializeField] private string inputNameHorizontal;
    [SerializeField] private string inputNameJump;
    bool isGrounded, canClimb;

    //public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        horizontal = Input.GetAxisRaw(inputNameHorizontal);
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        body.velocity = new Vector2(horizontal * moveSpeed, body.velocity.y);


        if (isGrounded && Input.GetButtonDown(inputNameJump))
        {

            body.AddForce(new Vector2(0, jumpStregth));
            isGrounded = false;
        }
        else if(canClimb && Input.GetButton(inputNameJump))
        {
            body.AddForce(new Vector2(0, climbForce));
            canClimb = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder1"))
        {
            canClimb = true;
            climbForce = 550;
        }
        if (collision.CompareTag("Ladder2"))
        {
            canClimb = true;
            climbForce = 300;
        }
    }
}
//https://youtube.com/playlist?list=PLiyfvmtjWC_Ugm9c9Q7WaoRFGBZh_Z6ys&si=XGDgVasGYrZkyPb9
//anim -> https://www.youtube.com/watch?v=whzomFgjT50&ab_channel=Brackeys
//https://www.youtube.com/watch?v=miI82pJCxSY&ab_channel=SharkGames

//Grounded -> https://www.youtube.com/watch?v=P_6W-36QfLA