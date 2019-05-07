using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFireballMovement : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rigidBody;
    private Vector2 playerPosition;
    private float maxExplosionDuration;
    private float currentExplosionDuration;
    private bool exploding;

    void Start()
    {
        speed = 0.2f;
        rigidBody = GetComponent<Rigidbody2D>();
        playerPosition = GameObject.FindWithTag("Player").transform.position;
        playerPosition = new Vector2(playerPosition.x + Random.Range(-1f, 1f), playerPosition.y);
        rigidBody.velocity = Vector2.up * speed;
        maxExplosionDuration = 0.1f;
        currentExplosionDuration = 0;
        exploding = false;

    }
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, playerPosition, speed);
        transform.localScale += new Vector3(0.01f, 0.01f, 0f);
        if (playerPosition.y + 0.05 >= transform.position.y)
        {
            exploding = true;
        }
        if (exploding)
        {
            transform.localScale += new Vector3(0.05f, 0.05f, 0f);
            currentExplosionDuration += Time.deltaTime;
        }
        if (currentExplosionDuration > maxExplosionDuration)
        {
            Destroy(this.gameObject);
        }
    }
}
