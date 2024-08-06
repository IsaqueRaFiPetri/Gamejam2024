using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D body;
    float horizontal, vertical;

    bool isGrounded, canClimb;
    PlayerStats playStats;    

    public float moveSpeed;
    public float jumpStregth;
    [SerializeField] private string inputNameHorizontal;
    [SerializeField] private string inputNameJump;
    [SerializeField] private string inputNameVertical;


    //public Animator animator;
    
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        playStats= GetComponent<PlayerStats>();
        SetPlataformMode();
    }

    private void Update()
    {
        if (gameObject.CompareTag("Ladder"))
        {
            body.velocity = new Vector2(horizontal * moveSpeed, vertical * moveSpeed);
            body.isKinematic = true;
            canClimb = true;
        }
        else
        {
            body.isKinematic = false;
            canClimb = false;
            body.velocity = new Vector2(horizontal * moveSpeed, body.velocity.y);


            if (isGrounded && Input.GetButton(inputNameJump))
            {

                body.AddForce(new Vector2(0, jumpStregth));
                isGrounded = false;
            }
        }
    }

    private void FixedUpdate()
    {
        horizontal = Input.GetAxisRaw(inputNameHorizontal);
        vertical = Input.GetAxisRaw(inputNameVertical);
        print(canClimb);
    }

    #region Estilo de Movimentação
    public void PlataformMove()
    {
        body.velocity = new Vector2(horizontal * moveSpeed, body.velocity.y);


        if (isGrounded && Input.GetButton(inputNameJump))
        {

            body.AddForce(new Vector2(0, jumpStregth));
            isGrounded= false;
        }
    }
    public void TopDownMove()
    {
        body.velocity = new Vector2(horizontal * moveSpeed, vertical * moveSpeed);
    }

    #endregion Estilo de Movimentação

    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    /*private void OnTriggerStay(Collider col)
    {
        if (col.gameObject.CompareTag("Ladder"))
        {
            body.isKinematic = true;
            canClimb = true;
            SetTopDownMode();
        }
        else
        {
            body.isKinematic = false;
            canClimb = false;
            SetPlataformMode();
        }
    }*/

    public void SetTopDownMode()
    {
        playStats.modes = PlayerModes.TopDown;
        TopDownMove();
    }
    public void SetPlataformMode()
    {
        playStats.modes = PlayerModes.Plataforma;
        PlataformMove();
    }
}



//https://youtube.com/playlist?list=PLiyfvmtjWC_Ugm9c9Q7WaoRFGBZh_Z6ys&si=XGDgVasGYrZkyPb9
//anim -> https://www.youtube.com/watch?v=whzomFgjT50&ab_channel=Brackeys
//https://www.youtube.com/watch?v=miI82pJCxSY&ab_channel=SharkGames

//Grounded -> https://www.youtube.com/watch?v=P_6W-36QfLA