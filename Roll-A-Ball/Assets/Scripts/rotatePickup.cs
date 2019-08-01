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

        // consolidate spectral data to 10 partitions (1 partition for each rotating cube)
        int numPartitions = 10;
        float[] aveMag = new float[numPartitions];
        //The index of the pickup child currently accessing the script
        int pickupIndex = transform.GetSiblingIndex();

        for (int i = 0; i < 10; i++) {
            //add up 10 bins each from spectral data for each pickup
            aveMag[pickupIndex] += audioSplitter.spectrumData[((10 * pickupIndex) + i)];
            }

        // scale and bound the average magnitude.
        for (int i = 0; i < numPartitions; i++)
        {
            aveMag[i] = (float)0.5 + aveMag[i] * 5;
            if (aveMag[i] > 5)
            {
                aveMag[i] = 5;
            }
        }

        // Map the magnitude to the pickups to transform scale
        float lerpValue = Mathf.Lerp(transform.localScale.x, aveMag[pickupIndex], 0.5f);
        transform.localScale = new Vector3(lerpValue, lerpValue, lerpValue);


    }
}