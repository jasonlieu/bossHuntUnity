using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFastAttackMovement : MonoBehaviour
{
    public float speed;
    public GameObject explosionTrap;
    private Rigidbody2D rigidBody;
    private Vector2 playerPosition;
    private float groundY;
    private float currentDelayTime;
    private float totalDelayDuration;
    private float maxExplosionDuration;
    private float currentExplosionDuration;
    private bool exploding;
    void Start()
    {
        currentDelayTime = 0;
        totalDelayDuration = 0.5f;
        speed = 0;
        maxExplosionDuration = 0.1f;
        currentExplosionDuration = 0;
        exploding = false;
        rigidBody = GetComponent<Rigidbody2D>();
        rigidBody.velocity = Vector2.up * speed;
        transform.localScale = new Vector3(0, 0, 0);
        groundY = GameObject.FindWithTag("Ground").transform.position.y + GameObject.FindWithTag("Ground").transform.localScale.y / 2f;
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
            transform.position = Vector3.MoveTowards(transform.position, new Vector2(playerPosition.x, groundY), speed);
        }
        if (groundY >= transform.position.y && !exploding)
        {
            exploding = true;
        }
        if (exploding)
        {
            transform.localScale += new Vector3(0.1f, 0.2f, 0.1f);
            currentExplosionDuration += Time.deltaTime;
        }
        if(currentExplosionDuration > maxExplosionDuration)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            exploding = true;
        }
    }
}
