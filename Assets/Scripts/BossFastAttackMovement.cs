using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFastAttackMovement : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rigidBody;
    private Vector2 playerPosition;
    private float currentDelayTime;
    private float totalDelayDuration;
    void Start()
    {
        currentDelayTime = 0;
        totalDelayDuration = 0.5f;
        speed = 0;
        rigidBody = GetComponent<Rigidbody2D>();
        rigidBody.velocity = Vector2.up * speed;
        transform.localScale = new Vector3(0, 0, 0);

    }
    void Update()
    {
        if (currentDelayTime < totalDelayDuration)
        { 
            playerPosition = GameObject.FindWithTag("Player").transform.position;
            currentDelayTime += Time.deltaTime;
            transform.localScale += new Vector3(0.003f, 0.003f, 0.003f);
        }
        else
        {
            speed = 0.4f;
            transform.position = Vector3.MoveTowards(transform.position, playerPosition, speed);
        }
        if (playerPosition.y + 0.05 >= transform.position.y)
        {
            Destroy(this.gameObject);
        }
    }
}
