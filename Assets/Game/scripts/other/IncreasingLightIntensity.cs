using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreasingLightIntensity : MonoBehaviour {

    public Light alight;
    public float value;
    public float theSpeed = 0.5f;

    void Start () {

        alight.intensity = 0;

    }

    void Update () {

        value = alight.intensity;

        if (alight.intensity < 9)
            alight.intensity += theSpeed * Time.deltaTime;

    }
}