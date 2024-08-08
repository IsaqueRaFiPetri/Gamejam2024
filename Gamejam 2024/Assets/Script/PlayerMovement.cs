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
    List<Zipline> lines = new List<Zipline>(); // -> lista

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
    Transform playerPos;

    public UnityEvent OnNormal, OnStairs, OnZipLine;

    public Animator animator;

    void Start()
    {
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
        switch (state)
        {
            case PlayerStates.Normal:
                body.velocity = new Vector2(horizontal * moveSpeed, body.velocity.y);

                if (isGrounded && Input.GetButton(inputNameJump))
                {

                    body.AddForce(new Vector2(0, jumpStregth));
                    isGrounded = false;
                }
                break;
            case PlayerStates.Stairs:
                if (canClimb && Input.GetButton(inputNameVertical))
                {
                    body.velocity = new Vector2(horizontal * moveSpeed, vertical * moveSpeed);
                }
                break;
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
            body.velocity = Vector2.zero;
        }
        else
        {
            SetPlayerState(PlayerStates.Normal);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            canClimb = true;
            SetPlayerState(PlayerStates.Stairs);
        }
        else
        {
            SetPlayerState(PlayerStates.Normal);
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


    /*private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            canClimb = false;
            SetPlayerState(PlayerStates.Normal);
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
        }
    }
}

//https://youtube.com/playlist?list=PLiyfvmtjWC_Ugm9c9Q7WaoRFGBZh_Z6ys&si=XGDgVasGYrZkyPb9
//anim -> https://www.youtube.com/watch?v=whzomFgjT50&ab_channel=Brackeys
//https://www.youtube.com/watch?v=miI82pJCxSY&ab_channel=SharkGames

//Grounded -> https://www.youtube.com/watch?v=P_6W-36QfLA