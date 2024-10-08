using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum PlayerStates
{
    Normal, Stairs, //ZipLine
}
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D body;
    float horizontal, vertical;
    
    [Header("Variaveis de For�a")]
    public float moveSpeed;
    public float jumpStregth;
    float climbForce;
    PlayerStates state;

    [Header("Nome dos Input")]
    [SerializeField] private string inputNameHorizontal;
    [SerializeField] private string inputNameJump;
    [SerializeField] private string inputNameVertical;
    bool isGrounded, canClimb;
    Transform playerPos;

    public UnityEvent OnNormal, OnStairs, OnZipLine;

    public Animator anim;

    bool isJump, isWalk;
    public SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        body = GetComponent<Rigidbody2D>();
        playerPos = GetComponent<Transform>();
        SetPlayerState(PlayerStates.Normal);
    }

    void Update()
    {
        print(state);

        switch (state)
        {
            case PlayerStates.Normal:
                horizontal = Input.GetAxisRaw(inputNameHorizontal);
                break;
            case PlayerStates.Stairs:
                vertical = Input.GetAxisRaw(inputNameVertical);
                break;
        }
    }
    
    void FixedUpdate()
    {
        if(state == PlayerStates.Normal)
        {
            body.velocity = new Vector2(horizontal * moveSpeed, body.velocity.y);
            
            if (horizontal <= -0.01f) 
            {
                spriteRenderer.flipX = true;
            }
            if (horizontal >= 0.01f)
            {
                spriteRenderer.flipX = false;
            }
            
            if (isGrounded && Input.GetButton(inputNameJump))
            {
                body.AddForce(new Vector2(0, jumpStregth));
                isGrounded = false;
            }
            if (Input.GetButton(inputNameHorizontal))
            {
                anim.SetBool("IsWalking", true);
            }
            else
            {
                anim.SetBool("IsWalking", false);
            }
        }
        if(state == PlayerStates.Stairs)
        {
            if (canClimb && Input.GetButton(inputNameVertical))
            {
                anim.SetBool("isClimbing", true);
                body.velocity = new Vector2(body.velocity.x, vertical * moveSpeed);
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground") || other.gameObject.CompareTag("Plataform"))
        {
            isGrounded = true;
            SetPlayerState(PlayerStates.Normal);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            canClimb = true;
            SetPlayerState(PlayerStates.Stairs);
        }
        /*else if (collision.CompareTag("ZipLine"))
        {
            SetPlayerState(PlayerStates.ZipLine);
        }
        */
        else
        {
            //SetPlayerState(PlayerStates.Normal);
        }
    }

    
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            canClimb = false;
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
            /*case PlayerStates.ZipLine:
                OnZipLine.Invoke();
                break; */
        }
    }
}

//https://youtube.com/playlist?list=PLiyfvmtjWC_Ugm9c9Q7WaoRFGBZh_Z6ys&si=XGDgVasGYrZkyPb9
//anim -> https://www.youtube.com/watch?v=whzomFgjT50&ab_channel=Brackeys
//https://www.youtube.com/watch?v=miI82pJCxSY&ab_channel=SharkGames

//Grounded -> https://www.youtube.com/watch?v=P_6W-36QfLA