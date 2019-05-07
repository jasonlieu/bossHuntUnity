using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
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
        if (col.gameObject.name != "fieldForeground")
        {
            //print("hit");
            //Destroy(col.gameObject);
        }
    }

}
