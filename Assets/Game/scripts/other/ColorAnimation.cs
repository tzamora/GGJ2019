using System.Collections;
using System.Collections.Generic;
using matnesis.TeaTime;
using UnityEngine;
using UnityEngine.UI;

public class ColorAnimation : MonoBehaviour {

    public Text ourText;

    [Space (5)]

    public float waitTime = 0.75f;
    public float timeSpeed = 2f;

    float ourTime;

    [Space (5)]

    public bool generateRandom = true;

    [Space (5)]

    public Color color1 = Color.gray;
    public Color color2 = Color.white;

    int id = 0;

    void OnEnable () {
        StartCoroutine (SpeedChange ());
    }

    // THIS SCRIPT CHANGES THE COLORS RANDOMLY
    void Update () {
        ourTime += timeSpeed * Time.deltaTime;

        // COLOR 1
        if (id == 1 && ourText.color != color1) {
            ourText.color =
                Color.Lerp (ourText.color, color1, ourTime);
        }

        // COLOR 2
        if (id == 2 && ourText.color != color2) {
            ourText.color =
                Color.Lerp (ourText.color, color2, ourTime);
        }

    }

    IEnumerator SpeedChange () {

        while (true) {

            if (generateRandom)
                color1 = new Vector4 (Random.Range (0.5f, 1), Random.Range (0.5f, 1), Random.Range (0.5f, 1), 255);

            id = 1;
            ourTime = 0;
            yield return new WaitForSecondsRealtime (waitTime);

            if (generateRandom)
                color2 = new Vector4 (Random.Range (0.5f, 1), Random.Range (0.5f, 1), Random.Range (0.5f, 1), 255);

            id = 2;
            ourTime = 0;
            yield return new WaitForSecondsRealtime (waitTime);

        }
    }
}