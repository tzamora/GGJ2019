using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseFuelShow : MonoBehaviour {

    public float maxFuelSize = 100f;
    public float maxActualSize = 0.8f;

    Transform fuelObjectSize;

    public float inputFuelValue;
    public GameObject energiaObject;

    void Start () {

        fuelObjectSize = energiaObject.transform;

    }

    void Update () {

        float theValue = inputFuelValue / maxFuelSize * maxActualSize;

        print (" values is  " + theValue);

        //maxActualSize * 100;

        if (theValue > maxActualSize) theValue = maxActualSize;

        Vector3 theSize = new Vector3 (1, 1, theValue);
        fuelObjectSize.localScale = theSize;

    }

}