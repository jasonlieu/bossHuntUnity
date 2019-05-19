using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FingerHitbox : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] fingerHB = GameObject.FindGameObjectsWithTag("fingerHB");
        foreach (GameObject x in fingerHB)
        {
            Destroy(x);
        }
    }

    private void OnCollisionEnter2D(Collision2D col) 
    { 
        if (col.gameObject.tag == "add")
        {
            Destroy(col.gameObject);
            KillMeter.currentKills += 1;
            KillMeter.score += 100; 
        }
        else if (col.gameObject.tag == "bossObject")
        {
            KillMeter.currentKills -= 1;
        }
    }
}
