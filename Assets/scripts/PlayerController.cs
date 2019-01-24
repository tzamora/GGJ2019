using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using matnesis.TeaTime;
using InControl;

public class PlayerController : MonoBehaviour
{
    public string playerName;

    public GameObject body;

    public float speed;

    public AudioClip starSound;

    public GamePlayerInput gamePlayerInput;

    private GameInputActions actions;

    // Start is called before the first frame update
    void Start()
    {
        //GameInputBinding();

        actions = gamePlayerInput.actions;

        InputRoutine();

        RotationRoutine();

        SoundsRoutine();
    }

    void Update()
    {
        if (gamePlayerInput.actions.attack.WasPressed)
        {
            print("Action from: " + playerName);
        }
    }

    //void GameInputBinding()
    //{
    //    gameInputActions = new GameInputActions();

    //    gameInputActions.Left.AddDefaultBinding(Key.LeftArrow);
    //    gameInputActions.Left.AddDefaultBinding(InputControlType.DPadLeft);

    //    gameInputActions.Right.AddDefaultBinding(Key.RightArrow);
    //    gameInputActions.Right.AddDefaultBinding(InputControlType.DPadRight);

    //    gameInputActions.attack.AddDefaultBinding(Key.Space);
    //    gameInputActions.attack.AddDefaultBinding(InputControlType.Action1);
    //}

    void InputRoutine() {

        this.tt().Loop((ttHandler handler) => {

            body.transform.Rotate(speed * Vector3.right * Time.deltaTime);


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
