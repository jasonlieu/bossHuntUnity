using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceToJump : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public Transform groundCheck;
    private bool grounded = false;
    public bool jump = false;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
        if (Input.GetButton("Jump") && grounded)
        {
            //print("jump");
            //rb2d.AddForce(new Vector2(rb2d.velocity.x, 1000f));
            jump = true;
        }
    }

    void FixedUpdate()
    {
        if (jump)
        {
            //anim.SetTrigger("Jump");
            rb2d.AddForce(new Vector2(0f, 1350f));
            jump = false;
        }
    }

}
