using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed;
    public float jumpHeight;

    [SerializeField]
    LayerMask platformLayerMask;

    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private Collider2D collider;
    private Rigidbody2D rb;
    private float movement;
    private bool jumped = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        collider = GetComponent<Collider2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame, we do our input collection and animation handling here
    void Update()
    {
        movement = Input.GetAxis("Horizontal") * speed;

        if (!jumped && IsGrounded())
        {
            jumped = Input.GetButtonDown("Jump");
        }

        animator.SetFloat("speed", Mathf.Abs(rb.velocity.x));
        if (Mathf.Abs(rb.velocity.x) > 0) 
        {
            spriteRenderer.flipX = rb.velocity.x < 0;
        }
        animator.SetFloat("jumpSpeed", Mathf.Abs(rb.velocity.y));
    }

    //Fixed Update runs ona  regular interval, we do our physics calculations here
    private void FixedUpdate()
    {

        if (jumped)
        {
            rb.velocity = new Vector2(movement, jumpHeight);
            jumped = false;
        }
        else
        {
            rb.velocity = new Vector2(movement, rb.velocity.y);
        }

    }
    //Detect if the players feet are on the ground
    bool IsGrounded()
    {
        float margin = 0.05f;
        Vector2 point = collider.bounds.center;
        RaycastHit2D raycastHit2D = Physics2D.BoxCast(point, collider.bounds.size, 0f, Vector2.down, margin, platformLayerMask);
        bool grounded = raycastHit2D.collider ? raycastHit2D.collider.CompareTag("Ground") : false;

        return grounded;

    }


    //Detect when the player runs into a coin
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Coin"))
        {
            collision.GetComponent<CoinController>().Collect();
        }
        else if (collision.CompareTag("Hazard"))
        {
            GameManager.instance.LoseLevel();
        }
    }
}
