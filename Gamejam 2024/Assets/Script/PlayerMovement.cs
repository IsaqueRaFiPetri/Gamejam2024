using UnityEngine;
using UnityEngine.Events;

public enum PlayerStates
{
    Normal, Stairs, ZipLine
}
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D body;
    float horizontal, vertical;

    [Header("Variaveis de Força")]
    public float moveSpeed;
    public float jumpStregth;
    float climbForce;
    PlayerStates state;

    [Header("Nome dos Input")]
    [SerializeField] private string inputNameHorizontal;
    [SerializeField] private string inputNameJump;
    [SerializeField] private string inputNameVertical;
    bool isGrounded, canClimb;

    public UnityEvent OnNormal, OnStairs, OnZipLine;

    //public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        switch (state)
        {
            case PlayerStates.Normal:
                horizontal = Input.GetAxisRaw(inputNameHorizontal);
                break;
            case PlayerStates.Stairs:
                vertical = Input.GetAxisRaw(inputNameVertical);
                break;
            case PlayerStates.ZipLine:
                
                break;
        }
    }
    
    void FixedUpdate()
    {

        body.velocity = new Vector2(horizontal * moveSpeed, body.velocity.y);


        if (isGrounded && Input.GetButton(inputNameJump))
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
            SetPlayerState(PlayerStates.Normal);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            SetPlayerState(PlayerStates.Stairs);
        }
        else if (collision.CompareTag("ZipLine"))
        {
            SetPlayerState(PlayerStates.ZipLine);
        }
        else
        {
            SetPlayerState(PlayerStates.Normal);
        }
    }

    /*private void OnTriggerEnter2D(Collider2D collision)
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
    }*/

    void SetPlayerState(PlayerStates playState)
    {
        state = playState;
        switch (state)
        {
            case PlayerStates.Normal:
                OnNormal.Invoke();
                break;
            case PlayerStates.Stairs:
                OnStairs.Invoke();
                break;
            case PlayerStates.ZipLine:
                OnZipLine.Invoke();
                break;
        }
    }
}
//https://youtube.com/playlist?list=PLiyfvmtjWC_Ugm9c9Q7WaoRFGBZh_Z6ys&si=XGDgVasGYrZkyPb9
//anim -> https://www.youtube.com/watch?v=whzomFgjT50&ab_channel=Brackeys
//https://www.youtube.com/watch?v=miI82pJCxSY&ab_channel=SharkGames

//Grounded -> https://www.youtube.com/watch?v=P_6W-36QfLA