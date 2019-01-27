using System;
using System.Collections;
using System.Collections.Generic;
using InControl;
using matnesis.TeaTime;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    [Header ("Settings")]
    public string playerName;
    public int playerIndex;

    public GameObject body;

    public float walkSpeed = 2;
    public float runSpeed = 3;
    public float turnSpeed = 50;
    public float pushBackPower = 250;
    public int anxiousPoints = 30;

    [Header ("References")]
    public float resourcesObtained;



    public AudioClip starSound;
    public GamePlayerInput gamePlayerInput;
    public Rigidbody rbody;
    private GameInputActions actions;
    public Camera mainCam;

	bool walkingOnce = false;
	
    [Header ("Data")]
    public bool isRunning;
    private float horizontal, vertical;
    private Vector3 direction;
    private float speedModifier;
    private Vector3 cameraFoward;
    private float aimAngle;
    private Quaternion aimRotation;

    // Start is called before the first frame update
    void Start () {
        //GameInputBinding();
        actions = gamePlayerInput.actions;
    }

    private void Update () {

        //if (gamePlayerInput.actions.attack.WasPressed) {
        //    print ("button A");
        //}

        horizontal = gamePlayerInput.Movement.x;
        vertical = gamePlayerInput.Movement.y;

        speedModifier = isRunning ? runSpeed : walkSpeed;
    }

    private void FixedUpdate () {
        direction.x = horizontal;
        direction.z = vertical;
        

        // Follow camera forward axis as base direction
        if (mainCam != null) {
            cameraFoward = Vector3.Scale (mainCam.transform.forward, new Vector3 (1, 0, 1)).normalized;
            direction = direction.z * cameraFoward + direction.x * mainCam.transform.right;
        }

        // If moving
        if (direction.x != 0 || direction.z != 0) {
		
				//SoundManager.Get.PlayClip (starSound, true);
				
				// print("X  " + direction.x + "  Y  " + direction.y);
            // Rotate character
            aimAngle = Mathf.Atan2 (direction.x, direction.z) * Mathf.Rad2Deg;
            aimRotation = Quaternion.AngleAxis (aimAngle, Vector3.up);
            body.transform.rotation = Quaternion.Slerp (body.transform.rotation, aimRotation, turnSpeed * Time.deltaTime);
			
        }
		
		var vel = GetComponent<Rigidbody>().velocity;      //to get a Vector3 representation of the velocity
		float speed = vel.magnitude;             
		
		// print (speed);
		
        if (speed > 1  && !walkingOnce) {
		
			SoundManager.Get.PlayClip (starSound, true);
			walkingOnce = true;

		} else if (speed < 1  && walkingOnce) {
		
			SoundManager.Get.StopClip (starSound);
			walkingOnce = false;
			print("this is ");

		}


        direction *= speedModifier;
        direction.y = rbody.velocity.y;

        rbody.velocity = direction;
    }

    void SoundsRoutine () {
        this.tt ().Add (5, (ttHandler handler) => {

            SoundManager.Get.PlayClip (starSound, false);

        }).Repeat ();
    }

    public void KillPlayerRoutine() {
        print("player dead");
        this.body.GetComponent<Renderer>().enabled = false;
    }

    public void Recolect(int amount) {
        resourcesObtained += amount;
    }

    public void PushBack () {
        rbody.AddForce (-body.transform.forward * pushBackPower, ForceMode.Impulse);
    }
}