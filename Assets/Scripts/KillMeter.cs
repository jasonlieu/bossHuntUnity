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
    public Text scoreText;
    public static int score;
    public GameObject spawnerHUB;

    void Start()
    {
        scoreText = FindObjectOfType<Text>();
        killsNeeded = 100f; //change to how many kills before boss
        oneKillScale = transform.localScale.x / killsNeeded;
        currentKills = 0;
        transitionDone = false;
        inBossFight = false;
        score = 0;
        spawnerHUB = GameObject.FindWithTag("spawnerHUB");
    }

    // Update is called once per frame
    void Update()
    {

        scoreText.text = "Score: \n" + score.ToString();

        if (!inBossFight)
        {

            if (currentKills == killsNeeded)
            {
                if (!transitionDone)
                {
                    inBossFight = true;
                    DestoryAdds();
                    spawnerHUB.SetActive(false);
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
                score += 1000;
                Destroy(GameObject.FindWithTag("bossObject"));
                inBossFight = false;
                transitionDone = false;
                spawnerHUB.SetActive(true);
                GetComponent<Image>().color = new Color(1,1,1);

            }
        }
        transform.localScale = new Vector3(currentKills * oneKillScale, 1);
        if (currentKills > killsNeeded)
        {
            currentKills = killsNeeded;
        }

    }
    void DestoryAdds()
    {
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
