using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHPManager : MonoBehaviour
{
    private Animator anim;
    public static float currentHP;
    private float oneHPScale;
    private float maxHP;
    private bool dead;
    void Start()
    {
        maxHP = 100f;
        oneHPScale = transform.localScale.x / maxHP;
        currentHP = 100;
        dead = false;
        anim = GameObject.FindWithTag("Player").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (dead)
        {
            currentHP = 0;
        }
        if(currentHP <= 0 && !dead)
        {
            dead = true;
            //uncomment before final copy
            //Destroy(GameObject.Find("Fixed Joystick"));
            anim.SetTrigger("Die");
        }
        if (!dead && currentHP < maxHP)
        {
            currentHP += 0.1f;
        }
        transform.localScale = new Vector3(currentHP * oneHPScale, 1);
    }
}
