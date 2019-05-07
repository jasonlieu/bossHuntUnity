using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchShoot : MonoBehaviour
{
    public Vector2 touchDown, touchUp;
    public GameObject arrowSprite;
    private float buffer;
    private Vector2 bossPosition;

    void Start()
    {
        buffer = 125f; //minimum swipe length
        bossPosition = GameObject.FindWithTag("bossObject").transform.position;
    }
    void Update()
    {
        Shoot();

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            touchDown = Input.GetTouch(0).position;
        }
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            touchUp = Input.GetTouch(0).position;
            if (touchDown.y > touchUp.y && touchDown.y - touchUp.y > buffer)
            {
                float angle = Vector2.Angle(bossPosition, transform.position);
                if(transform.position.x > bossPosition.x)
                {
                    angle *= -1;
                }
                GameObject shot = Instantiate(arrowSprite, transform.position, 
                    Quaternion.Euler(transform.position.x, transform.position.y, angle));
            }
        }
    }
    void Shoot()
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
