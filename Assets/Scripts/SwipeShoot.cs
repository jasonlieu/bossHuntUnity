using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeShoot : MonoBehaviour
{
    public Vector2 touchDown, touchUp;
    public GameObject aimedShot;
    private float buffer;

    void Start()
    {
        buffer = 125f; //minimum swipe length
    }
    void Update()
    {
        /*if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            print("SWIPESHOOT DOWN-------------------");

            touchDown = Input.GetTouch(0).position;
        }
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            print("SWIPESHOOT UP   -------------------");

            touchUp = Input.GetTouch(0).position;
            if (touchDown.y < touchUp.y && touchUp.y - touchDown.y > buffer)
            {
                print("SWIPESHOOT FIRE-------------------");
                float angle = Vector2.Angle(touchDown, touchUp);
                GameObject shot = Instantiate(aimedShot, transform.position, 
                    Quaternion.Euler(transform.position.x, transform.position.y, angle));
            }
        }*/
    }
}
