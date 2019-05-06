using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestInput : MonoBehaviour
{
    public float speed;             //Floating point variable to store the player's movement speed.
    public GameObject arrowSprite;
    private Vector2 bossPosition;


    void Start()
    {
        bossPosition = GameObject.FindWithTag("bossObject").transform.position;

    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float fire = Input.GetAxis("Jump");
        transform.position = new Vector2(transform.position.x + (0.2f * moveHorizontal), transform.position.y);
        if (fire > 0)
        {
            float angle = Vector2.Angle(bossPosition, transform.position);
            if (transform.position.x > bossPosition.x)
            {
                angle *= -1;
            }
            GameObject shot = Instantiate(arrowSprite, transform.position,
                Quaternion.Euler(transform.position.x, transform.position.y, angle));
        }
    }
}
