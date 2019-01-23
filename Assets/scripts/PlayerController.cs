using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using matnesis.TeaTime;
using InControl;

public class PlayerController : MonoBehaviour
{
    public GameObject body;

    public float speed;

    public AudioClip starSound;

    GameInputActions gameInputActions; 

    // Start is called before the first frame update
    void Start()
    {
        GameInputBinding();

        InputRoutine();

        RotationRoutine();

        SoundsRoutine();
    }

    void Update()
    {
        if (gameInputActions.attack.WasPressed)
        {
            print("botonzaso");
        }
    }

    void GameInputBinding()
    {
        gameInputActions = new GameInputActions();

        gameInputActions.Left.AddDefaultBinding(Key.LeftArrow);
        gameInputActions.Left.AddDefaultBinding(InputControlType.DPadLeft);

        gameInputActions.Right.AddDefaultBinding(Key.RightArrow);
        gameInputActions.Right.AddDefaultBinding(InputControlType.DPadRight);

        gameInputActions.attack.AddDefaultBinding(Key.Space);
        gameInputActions.attack.AddDefaultBinding(InputControlType.Action1);
    }

    void InputRoutine() {

        this.tt().Loop((ttHandler handler) => {

            var inputDevice = InputManager.ActiveDevice;
            //print(inputDevice.LeftStickX);
            body.transform.Rotate(speed * Vector3.right * Time.deltaTime * inputDevice.LeftStickX);


        });

    }

    void RotationRoutine()
    {

        //this.tt().Loop((ttHandler handler) => {
        //    body.transform.Rotate(speed * Vector3.right * Time.deltaTime);
        //});

    }

    void SoundsRoutine()
    {
        this.tt().Add(5, (ttHandler handler) => {

            SoundManager.Get.PlayClip(starSound, false);

        }).Repeat();
    }
}
