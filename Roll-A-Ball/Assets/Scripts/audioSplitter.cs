using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Ensure that we always have audio to use
[RequireComponent(typeof(AudioSource))]

public class audioSplitter : MonoBehaviour
{
    AudioSource audioSource;
    //An array to hold the spectrum data of the audio sample, must be a power of 2
    public static float[] spectrumData = new float[256];


    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //Unity built-in function to grab FFT data. This will put frequency values
        //into the 256 different bins
        audioSource.GetSpectrumData(spectrumData, 0, FFTWindow.Hanning);
    }
}
