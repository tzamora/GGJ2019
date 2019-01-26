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

    public TriggerController bodyCollider;

    // Start is called before the first frame update
    void Start()
    {
        //GameInputBinding();

        actions = gamePlayerInput.actions;

        SoundsRoutine();
    }

    private void FixedUpdate()
    {
        //print(gamePlayerInput.Movement.x);
        //print(gamePlayerInput.Movement.y);

        if (bodyCollider.isColliding) {
            print("colisionando");
        }

    }

    void Update()
    {
        if (gamePlayerInput.actions.attack.IsPressed)
        {
            print("Action from: " + playerName);
            body.transform.Rotate(speed * Vector3.right * Time.deltaTime);
        }
    }

    void SoundsRoutine()
    {
        this.tt().Add(5, (ttHandler handler) => {

            SoundManager.Get.PlayClip(starSound, false);

        }).Repeat();
    }
}
