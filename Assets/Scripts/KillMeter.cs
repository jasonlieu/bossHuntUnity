using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillMeter : MonoBehaviour
{
    public static float currentKills;
    private float oneKillScale;
    private float killsNeeded;
    void Start()
    {
        killsNeeded = 5f; //change to how many kills before boss
        oneKillScale = transform.localScale.x / killsNeeded;
        currentKills = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentKills > killsNeeded)
        {
            currentKills = killsNeeded;
        }
        transform.localScale = new Vector3(currentKills * oneKillScale, 1);
        if(currentKills == killsNeeded)
        {
            DestoryAddsAndAddSpawners();
        }
    }
    void DestoryAddsAndAddSpawners()
    {
        GameObject[] spawners = GameObject.FindGameObjectsWithTag("addSpawner");
        foreach (GameObject spawner in spawners)
        {
            Destroy(spawner);
        }
        GameObject[] adds = GameObject.FindGameObjectsWithTag("add");
        foreach (GameObject add in adds)
        {
            Destroy(add);
        }
    }
}
