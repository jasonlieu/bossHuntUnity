using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterTeleport : MonoBehaviour
{
    private Vector2 touchDown, touchUp;
    private float buffer;
    void Start()
    {
        buffer = 125f; //minimum swipe length
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
            if (touchDown.x > touchUp.x && touchDown.x - touchUp.x > buffer) //move left
            {
                transform.position = new Vector2(transform.position.x - 2, transform.position.y);
            }
            if (touchDown.x < touchUp.x  && touchUp.x - touchDown.x > buffer) //move right
            {
                transform.position = new Vector2(transform.position.x + 2, transform.position.y);
            }
        }
    }
}