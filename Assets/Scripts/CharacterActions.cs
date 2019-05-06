using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterActions : MonoBehaviour
{
    private Vector2 touchDown, touchUp;
    private bool holdTouch;
    private float currentX;
    public GameObject arrowSprite;
    private float buffer;
    private Vector2 bossPosition;
    private int holdTime;
    void Start()
    {
        holdTouch = false;
        holdTime = 0;
        buffer = 125f; //minimum swipe length
        bossPosition = GameObject.FindWithTag("bossObject").transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            holdTouch = true;
            holdTime = 0;
            touchDown = Input.GetTouch(0).position;
        }
        if (Input.touchCount > 0 && holdTouch)
        {
            if (holdTime >= 4)
            {
                Vector2 currentTouch = Input.GetTouch(0).position;
                if (Camera.main.ScreenToWorldPoint(currentTouch).x > transform.position.x + 0.1f ||
                    Camera.main.ScreenToWorldPoint(currentTouch).x < transform.position.x - 0.1f)
                {
                    if (Camera.main.ScreenToWorldPoint(currentTouch).x > transform.position.x)
                    {
                        //if (transform.position.x > 0.5) {
                        transform.position = new Vector2(transform.position.x + 0.2f, transform.position.y);
                        //}
                    }
                    else if (Camera.main.ScreenToWorldPoint(currentTouch).x < transform.position.x)
                    {
                        transform.position = new Vector2(transform.position.x - 0.2f, transform.position.y);
                    }
                }
            }
            holdTime++;
        }
        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        { 
            holdTouch = false;
            if (holdTime < 5)
            {
                float angle = Vector2.Angle(bossPosition, transform.position);
                if (transform.position.x > bossPosition.x)
                {
                    angle *= -1;
                }
                GameObject shot = Instantiate(arrowSprite, transform.position,
                    Quaternion.Euler(transform.position.x, transform.position.y, angle));
            }
            /*holdTouch = false;
            touchUp = Input.GetTouch(0).position;
            if (touchDown.y < touchUp.y && touchUp.y - touchDown.y > buffer)
            {
                float angle = Vector2.Angle(bossPosition, transform.position);
                if (transform.position.x > bossPosition.x)
                {
                    angle *= -1;
                }
                GameObject shot = Instantiate(arrowSprite, transform.position,
                    Quaternion.Euler(transform.position.x, transform.position.y, angle));
            }*/

        }
    }
}
