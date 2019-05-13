using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillMeter : MonoBehaviour
{
    public static float currentKills;
    private float oneKillScale;
    public static float killsNeeded;
    public GameObject boss;
    private bool transitionDone;
    void Start()
    {
        killsNeeded = 3f; //change to how many kills before boss
        oneKillScale = transform.localScale.x / killsNeeded;
        currentKills = 0;
        transitionDone = false;
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
            if (!transitionDone)
            {
                DestoryAddsAndAddSpawners();
                SpawnBoss();
                transitionDone = true;
            }
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
    void SpawnBoss()
    {
        Instantiate(boss, new Vector3(15f,0,5f), Quaternion.identity);
    }
}
