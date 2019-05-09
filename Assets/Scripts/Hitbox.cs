using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour
{
    private Animator anim;
    private int hit = 0;
    private GameObject health;
    private float healthPercent;
    private float currentHP;
    private bool dead;
    private float damageTick;

    // Start is called before the first frame update
    void Start()
    {
        dead = false;
        currentHP = 100;
        health = GameObject.FindWithTag("healthBar");
        healthPercent = health.transform.localScale.x / 100;
        anim = GameObject.FindWithTag("Player").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHP < 100 && !dead)
        {
            currentHP += 0.2f;
            health.transform.localScale = new Vector3(currentHP * healthPercent, 0.45f);
        }
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
        damageTick = 0;
        if (col.gameObject.tag == "bossFastAttack")
        {
            damageTick = 5;
        }
        else if (col.gameObject.tag == "bossFireball")
        {
            damageTick = 1;
        }
        currentHP -= damageTick;
        if (currentHP < 0)
        {
            currentHP = 0;
        }
        if (currentHP == 0 && !dead)
        {
            dead = true;
            Destroy(GameObject.Find("Fixed Joystick"));
            Destroy(GameObject.Find("Joybutton"));
            anim.SetTrigger("Die");
        }
        health.transform.localScale = new Vector3(currentHP * healthPercent, 0.45f);
    }

}
