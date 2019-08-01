using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotatePickup : MonoBehaviour
{
    private float displacement;
    private float bobbingRate;
    private float waitTime;
    private float bobbingCounter;

    private void Start()
    {
        //Generate a rand for variation in up/down movement
        bobbingRate = Random.Range(0.01f, 0.03f);
        waitTime = 3f + Random.Range(1f, 3f);
        bobbingCounter = 0;

    }

    // Update is called once per frame
    void Update()
    {
        //Rotate the pickup
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);

        //Check to see if initial wait time has passed
        if(Time.time >= waitTime) {
            //Bob the pickup up and down
            displacement = Mathf.Sin(bobbingCounter) * bobbingRate;
            transform.position += new Vector3(0, displacement, 0);
            bobbingCounter += 0.03f;
        }
    }
}
