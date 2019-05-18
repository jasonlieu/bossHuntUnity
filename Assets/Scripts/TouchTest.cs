using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchTest : MonoBehaviour
{ 
    private Transform heroTransform;
    public GameObject FingerHitbox;

    private void Start()
    {
        heroTransform = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    { 
        Touch touch = Input.GetTouch(0);
        Vector3 fingerPos = touch.position;
        Vector3 objPos = Camera.main.ScreenToWorldPoint(fingerPos);
        Instantiate(FingerHitbox, objPos, Quaternion.identity);
    }
}
