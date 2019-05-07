using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimedShotMovement : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rigidBody;
    private Vector2 screen;
    //private Vector2 bossPosition;
    void Start()
    {
        speed = 0.2f;
        screen = Camera.main.WorldToScreenPoint(transform.position);
        rigidBody = GetComponent<Rigidbody2D>();
        rigidBody.velocity = Vector2.up * speed;
    }
    void Update()
    {
        //transform.position = Vector3.MoveTowards(transform.position, bossPosition, speed);
        //destroy when offscreen
        if (screen.y > Screen.height || screen.y < 0)
            Destroy(this.gameObject);
    }
}
