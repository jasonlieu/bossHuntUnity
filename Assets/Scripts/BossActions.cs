using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossActions : MonoBehaviour
{
    private Vector2 playerPosition; 
    private float chargeTime;
    public GameObject bossFireball;
    public GameObject bossFastAttack;
    public bool inAnimation;
    private float currentAnimationTime;
    private float timeBetweenAttacks;
    private float attackDuration;
    private float selectAttack;
    private Rigidbody2D rb2d;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.freezeRotation = true;
        rb2d.constraints = RigidbodyConstraints2D.FreezeAll;
        playerPosition = GameObject.FindWithTag("Player").transform.position;
        chargeTime = 0;
        inAnimation = false;
        currentAnimationTime = 0;
        timeBetweenAttacks = 0.7f;
        attackDuration = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerHPManager.currentHP > 0)
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
    }
    void AOEWarning()
    {

    }
    void ShootProjectile()
    {
        playerPosition = GameObject.FindWithTag("Player").transform.position;
        if (transform.position.x - playerPosition.x < 15) {
            Instantiate(bossFireball, transform.position, Quaternion.identity);
        }
    }
    void ShootFastProjectile()
    {
        playerPosition = GameObject.FindWithTag("Player").transform.position;
        if (transform.position.x - playerPosition.x < 15)
        {
            Instantiate(bossFastAttack, transform.position, Quaternion.identity);
        }
    }
}
