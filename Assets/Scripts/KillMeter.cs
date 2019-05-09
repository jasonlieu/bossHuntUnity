using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillMeter : MonoBehaviour
{
    public static int currentKills;
    private float oneKillScale;
    private float killsNeeded;
    void Start()
    {
        killsNeeded = 30f;
        oneKillScale = transform.localScale.x / killsNeeded;
        currentKills = 0;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = new Vector3(currentKills * oneKillScale, 1);
    }
}
