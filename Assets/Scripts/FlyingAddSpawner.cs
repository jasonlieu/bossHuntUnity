using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingAddSpawner : MonoBehaviour
{
    private Vector2 playerPosition;
    public GameObject flyingAdd;
    private float spawnCooldown;
    private float timeElapsed;
    private float maxDistanceAway;
    void Start()
    {
        spawnCooldown = Random.Range(5f, 10f);
        maxDistanceAway = 15f;
        timeElapsed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;
        if (timeElapsed > spawnCooldown)
        {
            playerPosition = GameObject.FindWithTag("Player").transform.position;
            if (playerPosition.x > transform.position.x - maxDistanceAway && playerPosition.x < transform.position.x + maxDistanceAway)
            {
                Instantiate(flyingAdd, transform.position, Quaternion.identity);
                timeElapsed = 0;
                spawnCooldown = Random.Range(5f, 10f);
            }
        }

    }
}
