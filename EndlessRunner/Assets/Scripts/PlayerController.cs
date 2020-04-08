using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;
    private Rigidbody2D rigidbody;
    public bool onFloor;
    public LayerMask groundMask;
    //private Collider2D collider;
    private Animator animatorPlayer;
    public float jumpTime;
    private float jumpTimeCount;
    public Transform groundCheck;
    public float radious;
    public bool stopJumping;
    public bool doubleJumping;
    public GameManager gameManager;
    
    // Start is called before the first frame update
    void Start()
    {
        stopJumping = true;
        jumpTimeCount = jumpTime;

        rigidbody = GetComponent<Rigidbody2D>();
        //collider = GetComponent<Collider2D>();
        animatorPlayer = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //onFloor = Physics2D.IsTouchingLayers(collider, groundMask);
        onFloor = Physics2D.OverlapCircle(groundCheck.position, radious, groundMask);
        rigidbody.velocity = new Vector2(moveSpeed, rigidbody.velocity.y);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (onFloor)
            {
                stopJumping = false;
                rigidbody.velocity = new Vector2(rigidbody.velocity.x, jumpForce);
            }
            if (!onFloor && doubleJumping)
            {
                rigidbody.velocity = new Vector2(rigidbody.velocity.x, jumpForce);
                stopJumping = false;
                doubleJumping = false;
                jumpTimeCount = jumpTime;
            }                
        }
        if (Input.GetKey(KeyCode.Space) && !stopJumping) 
        {
            if (jumpTimeCount > 0)
            {
                rigidbody.velocity = new Vector2(rigidbody.velocity.x, jumpForce);
                jumpTimeCount -= Time.deltaTime;
            }           
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            stopJumping = true;
            jumpTimeCount = 0;
        }
        if (onFloor)
        {
            doubleJumping = true;
            jumpTimeCount = jumpTime;
        }
        animatorPlayer.SetFloat("MoveSpeed", rigidbody.velocity.x);
        animatorPlayer.SetBool("onFloor", onFloor);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
       if (collision.gameObject.tag=="invisibleObject")
        {
            gameManager.RestartGame();
        }
    }

}
