using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using matnesis.TeaTime;

public class PlayerController : MonoBehaviour
{
    public GameObject body;

    public float speed;

    public AudioClip starSound;

    // Start is called before the first frame update
    void Start()
    {
        RotationRoutine();

        SoundsRoutine();
    }

    void RotationRoutine()
    {

        this.tt().Loop((ttHandler handler) => {
            body.transform.Rotate(speed * Vector3.right * Time.deltaTime);
        });

    }

    void SoundsRoutine()
    {
        this.tt().Add(2, (ttHandler handler) => {

            SoundManager.Get.PlayClip(starSound, false);

        }).Repeat();
    }
}
