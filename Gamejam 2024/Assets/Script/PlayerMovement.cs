using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D body;
    float horizontal, jump;

    public float moveSpeed;
    public float jumpStregth;
    [SerializeField] private string inputNameHorizontal;
    [SerializeField] private string inputNameJump;
    bool isGrounded;

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


        if (isGrounded && Input.GetButton(inputNameJump))
        {

            body.AddForce(new Vector2(0, jumpStregth));
            isGrounded= false;
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
//https://youtube.com/playlist?list=PLiyfvmtjWC_Ugm9c9Q7WaoRFGBZh_Z6ys&si=XGDgVasGYrZkyPb9
//anim -> https://www.youtube.com/watch?v=whzomFgjT50&ab_channel=Brackeys
//https://www.youtube.com/watch?v=miI82pJCxSY&ab_channel=SharkGames

//Grounded -> https://www.youtube.com/watch?v=P_6W-36QfLA