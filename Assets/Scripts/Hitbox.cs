using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour
{
    private Animator anim;
    private int hit = 0;

    // Start is called before the first frame update
    void Start()
    {
        anim = GameObject.FindWithTag("Player").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    //collision detection w/ knock back
    /*void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name != "fieldForeground") {
            print("hit");
            Destroy(col.gameObject);
        }
    }*/

    //collision detection w/o knock back
    private void OnTriggerEnter2D(Collider2D col)
    {
        /*if (col.gameObject.name != "fieldForeground")
        {
            hit += 1;
            print("hit: " + hit);
            if (hit == 300)
            {
                Destroy(GameObject.Find("Canvas"));
                anim.SetTrigger("Die");
            }
            //Destroy(col.gameObject);
        }*/
        if (col.gameObject.tag == "bossFastAttack")
        {
            PlayerHPManager.currentHP -= 5;
        }
        else if (col.gameObject.tag == "bossFireball")
        {
            PlayerHPManager.currentHP -= 1;
        }
        else if (col.gameObject.tag == "add")
        {
            PlayerHPManager.currentHP -= 20;
            KillMeter.currentKills += 1;
        }
    }

}
