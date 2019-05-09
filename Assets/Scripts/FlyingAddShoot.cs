using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingAddShoot : MonoBehaviour
{
    private Vector2 playerPosition;
    private float shotCoolDown;
    private float timeElapsed;
    public GameObject bossFastAttack;
    void Start()
    {
        shotCoolDown = Random.Range(2f, 4f);
        timeElapsed = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;
        if (timeElapsed > shotCoolDown)
        {
            ShootAtPlayer();
            timeElapsed = 0;
            shotCoolDown = Random.Range(2f, 4f);
        }
    }

    void ShootAtPlayer()
    {
        playerPosition = GameObject.FindWithTag("Player").transform.position;
        Instantiate(bossFastAttack, transform.position, Quaternion.identity);
    }
}
