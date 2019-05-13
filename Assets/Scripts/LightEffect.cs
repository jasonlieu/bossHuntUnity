using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightEffect : MonoBehaviour
{
    private float growDuration;
    private float timeElasped;
    private float defaultXScale;
    private float staggerTime;
    private float staggerTimeElasped;
    void Start()
    {
        growDuration = 5f;
        timeElasped = 0f;
        staggerTime = 0.1f;
        staggerTimeElasped = 0f;
        defaultXScale = transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (KillMeter.currentKills == KillMeter.killsNeeded)
        {
            if (timeElasped < growDuration)
            {
                transform.localScale += new Vector3(0.05f, 0.05f, 0f);
                timeElasped += Time.deltaTime;
            }
            else
            {
                Destroy(this.gameObject);
            }
        }
        else
        {
            staggerTimeElasped += Time.deltaTime;
            if (staggerTimeElasped > staggerTime)
            {
                Stagger();
                staggerTimeElasped = 0;
            }
        }
    }
    void Stagger()
    {
        float randomValue = Random.Range(0.05f, 0.1f);
        if (transform.localScale.x >= defaultXScale)
        {
            transform.localScale -= new Vector3(randomValue, randomValue, 0f);
        }
        else
        {
            transform.localScale += new Vector3(randomValue, randomValue, 0f);
        }
    }
}
