using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotMovement : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rigidBody;
    private Vector2 screen;
    private Vector2 bossPosition;
    void Start()
    {
        speed = 0.5f;
        screen = Camera.main.WorldToScreenPoint(transform.position);
        rigidBody = GetComponent<Rigidbody2D>();
        bossPosition = GameObject.FindWithTag("bossObject").transform.position;
        //float angle = Vector2.Angle(bossPosition, transform.position);
        //transform.rotation = Quaternion.Euler(transform.position.x, transform.position.y, angle);
        rigidBody.velocity = Vector2.up * speed;
        //rigidBody.AddRelativeForce = angl
    }
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, bossPosition, speed);
        //destroy when offscreen
        //screen = Camera.main.WorldToScreenPoint(transform.position);
        //if (screen.y > Screen.height || screen.y < 0)
        //    Destroy(this.gameObject);
        if(bossPosition.y - 0.05 <= transform.position.y)
        {
            Destroy(this.gameObject);
        } 
    }
}
