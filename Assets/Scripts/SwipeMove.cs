using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeMove : MonoBehaviour
{
    private Vector2 touchDown, touchUp;
    private Vector2[] positions;
    private int currentPosition;
    private float buffer;
    void Start()
    {
        buffer = 125f; //minimum swipe length
        currentPosition = 3;
        positions = new Vector2[5] {
            new Vector2(transform.position.x - 6,transform.position.y + 1),
            new Vector2(transform.position.x - 3,transform.position.y + 0.3f),
            new Vector2(transform.position.x , transform.position.y),
            new Vector2(transform.position.x + 3,transform.position.y + 0.3f),
            new Vector2(transform.position.x + 6,transform.position.y + 1)
        };
        transform.position = positions[currentPosition];
    }

    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            touchDown = Input.GetTouch(0).position;
        }
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            touchUp = Input.GetTouch(0).position;
            if (touchDown.x > touchUp.x && currentPosition > 0 && touchDown.x - touchUp.x > buffer) //move left
            {
                transform.position = positions[currentPosition - 1];
                currentPosition--;
            }
            if (touchDown.x < touchUp.x && currentPosition < 4 && touchUp.x - touchDown.x > buffer) //move right
            {
                transform.position = positions[currentPosition + 1];
                currentPosition++;
            }
        }
    }
}
