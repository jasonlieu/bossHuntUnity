using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingAddAttack : MonoBehaviour
{
    public float speed;
    public GameObject explosionTrap;
    private Rigidbody2D rigidBody;
    private Vector2 playerPosition;
    private float groundY;

    void Start()
    {
        speed = 0.4f;
        rigidBody = GetComponent<Rigidbody2D>();
        rigidBody.velocity = Vector2.up * speed;
        playerPosition = GameObject.FindWithTag("Player").transform.position;
        groundY = GameObject.FindWithTag("Ground").transform.position.y + GameObject.FindWithTag("Ground").transform.localScale.y - 0.1f;
    }
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector2(playerPosition.x, groundY), speed);
        if (groundY >= transform.position.y)
        {
            Instantiate(explosionTrap, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            PlayerHPManager.currentHP -= 10f;
            Destroy(this.gameObject);
        }
    }
}
