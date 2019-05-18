using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KillMeter : MonoBehaviour
{
    public static float currentKills;
    private float oneKillScale;
    public static float killsNeeded;
    public GameObject boss;
    private bool transitionDone;
    private bool inBossFight;
    void Start()
    {
        killsNeeded = 3f; //change to how many kills before boss
        oneKillScale = transform.localScale.x / killsNeeded;
        currentKills = 0;
        transitionDone = false;
        inBossFight = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!inBossFight)
        {

            if (currentKills == killsNeeded)
            {
                if (!transitionDone)
                {
                    inBossFight = true;
                    DestoryAddsAndAddSpawners();
                    SpawnBoss();
                    transitionDone = true;
                }
            }
        }
        else
        {
            //currentKills -= 0.01f;
            if(currentKills == 0)
            {
                Destroy(GameObject.FindWithTag("bossObject"));
            }
        }
        transform.localScale = new Vector3(currentKills * oneKillScale, 1);
        if (currentKills > killsNeeded)
        {
            currentKills = killsNeeded;
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
        Instantiate(boss, new Vector3(15f, 0, 5f), Quaternion.identity);
        GetComponent<Image>().color = new Color(252f/255f, 93f/255f, 99f/255f);
    }
}
