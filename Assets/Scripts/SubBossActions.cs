using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubBossActions : MonoBehaviour
{
    private Vector2 playerPosition;
    private float projectileCDTimer;
    private float chargeTime;
    public GameObject bossFireball;
    public GameObject bossFastAttack;
    public bool inAnimation;
    private float currentAnimationTime;
    private float timeBetweenAttacks;
    private float attackDuration;
    private float selectAttack;
    void Start()
    {
        projectileCDTimer = 5;
        chargeTime = 0;
        inAnimation = false;
        currentAnimationTime = 0;
        timeBetweenAttacks = 2f;
        attackDuration = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (chargeTime > timeBetweenAttacks) //select an attack every timeBetweenAttacks seconds
        {
            chargeTime = 0;
            inAnimation = true;
            currentAnimationTime = 0;
            selectAttack = Random.value; //temp
        }
        if (inAnimation)
        {
            if (currentAnimationTime > attackDuration)
            {
                inAnimation = false;
            }
            else
            {
                if (selectAttack < 0.2)
                {
                    ShootProjectile();
                }
                else
                {
                    ShootFastProjectile();
                    currentAnimationTime += attackDuration;
                }
                currentAnimationTime += Time.deltaTime;
            }
        }
        else
        {
            chargeTime += Time.deltaTime;
        }
    }
    void AOEWarning()
    {

    }
    void ShootProjectile()
    {
        playerPosition = GameObject.FindWithTag("Player").transform.position;
        Instantiate(bossFireball, transform.position, Quaternion.identity);
    }
    void ShootFastProjectile()
    {
        playerPosition = GameObject.FindWithTag("Player").transform.position;
        Instantiate(bossFastAttack, transform.position, Quaternion.identity);
    }
}
