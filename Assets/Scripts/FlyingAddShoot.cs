using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingAddShoot : MonoBehaviour
{
    private float shotCoolDown;
    private float timeElapsed;
    public GameObject flyingAddAttack;
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
        Instantiate(flyingAddAttack, transform.position, Quaternion.identity);
    }
}
