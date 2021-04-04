using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;
    public float jumpForce;
    private float moveInput;

    private bool isGrounded;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask whatIsGround;

    public float fallMultipler = 2.5f;
    public float lowJumpMultipler = 2f;

    private Animator anim;

    public float hangTime = .2f;      // Время для прыжка "койота"
    private float hangCounter;

    public ParticleSystem stepParticles;
    private ParticleSystem.EmissionModule footEmission;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        footEmission = stepParticles.emission;
    }

    private void FixedUpdate()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        if (moveInput < 0)
        {
            transform.localScale = new Vector2(-1, 1);
            anim.SetBool("IsRunning", true);

        }
        else if (moveInput > 0)
        {
            transform.localScale = new Vector2(1, 1);
            anim.SetBool("IsRunning", true);
        }
        else
        {
            anim.SetBool("IsRunning", false);
        }
    }


    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);

        if (isGrounded)
        {
            hangCounter = hangTime;
        }
        else
        {
            hangCounter -= Time.deltaTime;
        }


        if (hangCounter > 0 && Input.GetButton("Jump"))
        {
            rb.velocity = Vector2.up * jumpForce;
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }

        // show footstep effects
        if (isGrounded && Input.GetAxisRaw("Horizontal") != 0)
        {
            footEmission.rateOverTime = 35f;
        }   
        else
        {
            footEmission.rateOverTime = 0f;
        }

    }

}
