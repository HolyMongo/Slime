using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour
{
    [SerializeField] private PlayerSO playerso;
    private Rigidbody2D rb;
    private float speed;

    private BoxCollider2D bc;
    private float jumpPower;
    [SerializeField] private float extraHeight = 0.2f;
    [SerializeField] private LayerMask groundLayer;

    private float jumpBuffer;
    private float groundedBuffer;

    private bool canDubbleJump = false;
    private bool dubbleJumpReady = false;

    [SerializeField][Range(1, 10)]
    private float fallMultiplier = 2.5f;
    [SerializeField][Range(1,10)]
    private float lowJumpMultiplier = 2f;
    //bool IsFalling;

    private AudioSource aD;
    private Animator anim;
    //public AnimationClip idle;
    //public AnimationClip jump;
    //public AnimationClip left;
    //public AnimationClip right;
    private float xDir;

    public void SetDubbleJumpTrue()
    {
        canDubbleJump = true;
        playerso.ChangeCanDubbleJump(true);
    }
    public void SetSpeedBoostTrue(float _speedBoost)
    {
        speed *= _speedBoost;
    }
    public void SetSpeedBoostFalse(float _speedBoost)
    {
        speed /= _speedBoost;
    }
    void Start()
    {
        playerso = GetComponent<ChooseSOForTheWholeThing>().GetPlayerSO(0);
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();
        aD = GetComponent<AudioSource>();

        speed = playerso.Speed();
        jumpPower = playerso.JumpPower();
        anim = GetComponent<Animator>();
        if (playerso.CanDubbleJump())
        {
            canDubbleJump = true;
        }
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            jumpBuffer = 0.12f;
         
        }
        if (GroundCheck())
        {
            groundedBuffer = 0.12f;
        }
        else
        {
            LessFloatyJump();
        }

        if (Input.GetButtonDown("Jump") && groundedBuffer > 0 || jumpBuffer > 0 && groundedBuffer > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
            aD.Play();
           
        }
        if (dubbleJumpReady && Input.GetButtonDown("Jump"))
        {
            dubbleJumpReady = false;
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
            aD.Play();
        }
       

       
        jumpBuffer -= Time.deltaTime;
        groundedBuffer -= Time.deltaTime;
        xDir = Input.GetAxisRaw("Horizontal");

        if(xDir == 0)
        {
            anim.SetBool("IsWalking", false);
           
        }
        else
        {
            anim.SetBool("IsWalking", true);
           
        }
        // På grund av dessa 2 if statements går det inte att höja Slime scale
        if(xDir < 0)
        {
            anim.SetBool("IsLeft", true);
            anim.SetBool("isRight", false);
        }
        else if(xDir > 0)
        {
            anim.SetBool("IsLeft", false);
            anim.SetBool("isRight", true);
        }
    }
    void FixedUpdate()
    {
        rb.velocity = new Vector2(xDir * speed, rb.velocity.y);
    }

    public void LessFloatyJump()
    {

        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y > 1.5f && !Input.GetButton("Jump"))
        {
            rb.velocity += Vector2.up * Physics2D.gravity * (lowJumpMultiplier - 1) * Time.deltaTime;
        }

        /*

        if (Input.GetButtonUp("Jump") || rb.velocity.y <= 0)
        {
            IsFalling = true;
        }

        if (IsFalling)
        {
            gravity -= Time.deltaTime * 10;
        }

        rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y + gravity * Time.deltaTime);
        */
    }

    public bool GroundCheck()
    {
        RaycastHit2D rayHit2D = Physics2D.BoxCast(bc.bounds.center, bc.bounds.size, 0f, Vector2.down, extraHeight, groundLayer);
        Color rayColor;
        if (rayHit2D.collider != null)
        {
            rayColor = Color.green;
            anim.SetBool("IsJumping", false);
            if (canDubbleJump)
            {
                dubbleJumpReady = true;
            }
        }
        else
        {
            rayColor = Color.red;
            anim.SetBool("IsJumping", true);
        }
        Debug.DrawRay(bc.bounds.center + new Vector3(bc.bounds.extents.x, 0f), Vector2.down * (bc.bounds.extents.y + extraHeight), rayColor);
        Debug.DrawRay(bc.bounds.center - new Vector3(bc.bounds.extents.x, 0f), Vector2.down * (bc.bounds.extents.y + extraHeight), rayColor);
        Debug.DrawRay(bc.bounds.center - new Vector3(bc.bounds.extents.x, bc.bounds.extents.y), Vector2.right * (bc.bounds.extents.x), rayColor);

        //IsFalling = false;
        //gravity = -9.81f;
        return rayHit2D.collider != null;
    }
}
