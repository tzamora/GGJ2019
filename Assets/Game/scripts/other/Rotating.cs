using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotating : MonoBehaviour {

    public Vector3 rotateSpeedValues = new Vector3 (100, 100, 100);
    public float randomSizeIntensity = 0.1f;
    // random start is away from capabilities
    public bool setRandomSpeed;
    public bool setRandomSize;
    public bool startRandomRotation;

    Vector3 rotateSpeed;

    public void Start () {
        //
        if (setRandomSize) transform.localScale =
            transform.localScale * Random.Range (1 - randomSizeIntensity,
                1 + randomSizeIntensity);
        //
        if (setRandomSpeed) {
            rotateSpeedValues.x = rotateSpeedValues.x * Random.Range (0.25f, 1);
            rotateSpeedValues.y = rotateSpeedValues.y * Random.Range (0.25f, 1);
            rotateSpeedValues.z = rotateSpeedValues.z * Random.Range (0.25f, 1);
        }
        //
        if (startRandomRotation)
            transform.localEulerAngles = rotateSpeedValues * Random.Range (0, 360);
        //
        rotateSpeed = rotateSpeedValues;
        //
    }

    void Update () {

        transform.Rotate (rotateSpeed * Time.deltaTime);

    }
}