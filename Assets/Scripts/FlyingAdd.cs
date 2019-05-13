using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingAdd : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector2 playerPosition;
    private Rigidbody2D rb2d;
    private bool facingLeft;
    public float moveForce = 5f;
    public float floatForce = 5f;
    private readonly float maxSpeed = 2.5f;
    private float floatSwitchTime;
    private float timeElapsed;
    private bool floatOrientation;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.freezeRotation = true;
        facingLeft = true;
        floatSwitchTime = 2f;
        timeElapsed = 0;
        floatOrientation = true;
    }

    // Update is called once per frame
    void Update()
    {
        playerPosition = GameObject.FindWithTag("Player").transform.position;
        moveForce = (playerPosition.x - transform.position.x) * 2f;
        if(moveForce < 0)
        {
            moveForce *= -1;
        }
        FollowPlayer();
        timeElapsed += Time.deltaTime;
        if(timeElapsed > floatSwitchTime)
        {
            floatOrientation = !floatOrientation;
            timeElapsed = 0;
        }
        Float();
    }

    void FollowPlayer()
    {

        if (playerPosition.x < transform.position.x)
        {
            if (!facingLeft && !(playerPosition.x > transform.position.x - 1f && playerPosition.x < transform.position.x + 1f))
            {
                Vector3 newScale = transform.localScale;
                newScale.x *= -1;
                transform.localScale = newScale;
                facingLeft = true;
            }
            rb2d.AddForce(new Vector2(-moveForce, 0));
        }
        else
        {
            if (facingLeft && !(playerPosition.x > transform.position.x - 1f && playerPosition.x < transform.position.x + 1f))
            {
                Vector3 newScale = transform.localScale;
                newScale.x *= -1;
                transform.localScale = newScale;
                facingLeft = false;
            }
            rb2d.AddForce(new Vector2(moveForce, 0));
        }
        if (rb2d.velocity.magnitude > maxSpeed)
        {
            rb2d.velocity = rb2d.velocity.normalized * maxSpeed;
        }
    }

    void Float()
    {
        if (floatOrientation) //float up
        {
            rb2d.AddForce(new Vector2(rb2d.velocity.x, floatForce));
        }
        else
        {
            rb2d.AddForce(new Vector2(rb2d.velocity.x, -floatForce));
        }
    }
}
