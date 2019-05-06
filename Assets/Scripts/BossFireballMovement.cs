using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFireballMovement : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rigidBody;
    private Vector2 playerPosition;
    void Start()
    {
        speed = 0.2f;
        rigidBody = GetComponent<Rigidbody2D>();
        playerPosition = GameObject.FindWithTag("Player").transform.position;
        playerPosition = new Vector2(playerPosition.x + Random.Range(-1f, 1f), playerPosition.y);
        rigidBody.velocity = Vector2.up * speed;
    }
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, playerPosition, speed);
        if (playerPosition.y + 0.05 >= transform.position.y)
        {
            Destroy(this.gameObject);
        }
    }
}
