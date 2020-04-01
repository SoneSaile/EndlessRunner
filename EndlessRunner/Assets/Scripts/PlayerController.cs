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
    
    // Start is called before the first frame update
    void Start()
    {
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
        if (Input.GetKeyDown(KeyCode.Space) && onFloor)
        {
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, jumpForce);

        }
        if (Input.GetKey(KeyCode.Space)) 
        {
            if (jumpTimeCount > 0)
            {
                rigidbody.velocity = new Vector2(rigidbody.velocity.x, jumpForce);
                jumpTimeCount -= Time.deltaTime;
            }           
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            jumpTimeCount = 0;
        }
        if (onFloor)
        {
            jumpTimeCount = jumpTime;
        }
        animatorPlayer.SetFloat("MoveSpeed", rigidbody.velocity.x);
        animatorPlayer.SetBool("onFloor", onFloor);
    }
}
