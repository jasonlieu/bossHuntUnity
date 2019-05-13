using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionTrap : MonoBehaviour
{
    private float explodeDuration;
    private float timeElapsed;
    private float timeBeforeDisappear;
    private float time;
    private bool explode;
    void Start()
    {
        explodeDuration = 0.1f;
        timeBeforeDisappear = 3f;
        timeElapsed = 0;
        time = 0;
        explode = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (explode)
        {
            if (timeElapsed < explodeDuration)
            {
                transform.localScale += new Vector3(0f, 0.2f);
                timeElapsed += Time.deltaTime;
            }
            else
            {
                Destroy(this.gameObject);
            }
        }
        else
        {
            time += Time.deltaTime;
            if (time > timeBeforeDisappear) 
            {
                Destroy(this.gameObject);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player" && !explode)
        {
            PlayerHPManager.currentHP -= 10;
            explode = true;
        }
    }
}
