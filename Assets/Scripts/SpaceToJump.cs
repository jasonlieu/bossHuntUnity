using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceToJump : MonoBehaviour
{
    private Rigidbody2D rb2d;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Jump"))
        {
            print("jump");
            rb2d.AddForce(new Vector2(rb2d.velocity.x, 10f));
        }
    }
}
