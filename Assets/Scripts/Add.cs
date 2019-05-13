using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Add : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector2 playerPosition;
    private Rigidbody2D rb2d;
    private bool facingLeft;
    public float moveForce = 5f;
    private readonly float maxSpeed = 3f;
    private readonly float timeBetweenHops = 1f;
    private float timeAfterLastHop;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.freezeRotation = true;
        timeAfterLastHop = 0;
        facingLeft = true;
    }

    // Update is called once per frame
    void Update()
    {
        playerPosition = GameObject.FindWithTag("Player").transform.position;
        FollowPlayer();
        timeAfterLastHop += Time.deltaTime;
        if (timeAfterLastHop > timeBetweenHops)
        {
            Hop();
            timeAfterLastHop = 0;
        }
    }

    void FollowPlayer()
    {
        if(playerPosition.x < transform.position.x)
        {
            if (!facingLeft)
            {
                Vector3 newScale = transform.localScale;
                newScale.x *= -1;
                transform.localScale = newScale;
                facingLeft = true;
            }
            rb2d.AddForce(new Vector2(-moveForce, rb2d.velocity.y ));
        }
        else
        {
            if (facingLeft)
            {
                Vector3 newScale = transform.localScale;
                newScale.x *= -1;
                transform.localScale = newScale;
                facingLeft = false;
            }
            rb2d.AddForce(new Vector2(moveForce, rb2d.velocity.y));
        }
        if (rb2d.velocity.magnitude > maxSpeed)
        {
            rb2d.velocity = rb2d.velocity.normalized * maxSpeed;
        }
    }

    void Hop()
    {
        rb2d.velocity = Vector2.up * 10f;
    }
}
