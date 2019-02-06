using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class PlayerMovement : MonoBehaviour
{
    [Header ("Settings")]
    public float walkSpeed = 2;
    public float runSpeed = 3;
    public float turnSpeed = 50;

    [Header ("Reference")]
    public Camera mainCam;
    private Player player;

    [Header ("Data")]
    public bool isRunning;
    private Vector3 direction;
    private float horizontal, vertical;
    private float playerSpeed;
    private Vector3 cameraFoward;
    private float aimAngle;
    private Quaternion aimRotation;

    private void Update ()
    {        
        if(player != null)
        {
            GetInput();
        }        
    }

    public void SetInput (Player p)
    {
        player = p;
    }

    public bool IsMoving ()
    {
        return direction.x != 0 || direction.z != 0;
    }

    public Vector3 GetDirection ()
    {
        return direction;
    }
    
    private void GetInput ()
    {
        isRunning = player.GetButton(ButtonNames.Run);

        playerSpeed = isRunning ? runSpeed : walkSpeed;

        horizontal = player.GetAxis(ButtonNames.Horizontal);
        vertical = player.GetAxis(ButtonNames.Vertical);

        direction.x = horizontal;
        direction.z = vertical;

        FollowCameraAxis();
        RotatePlayer();

        direction *= playerSpeed;
    }

    private void FollowCameraAxis ()
    {        
        // Follow camera forward axis as base direction
        if (mainCam != null) 
        {
            cameraFoward = Vector3.Scale (mainCam.transform.forward, new Vector3 (1, 0, 1)).normalized;
            direction = direction.z * cameraFoward + direction.x * mainCam.transform.right;
        }
    }

    private void RotatePlayer ()
    {
        // Rotate the character if moving
        if (IsMoving()) 
        {		
            aimAngle = Mathf.Atan2 (direction.x, direction.z) * Mathf.Rad2Deg;
            aimRotation = Quaternion.AngleAxis (aimAngle, Vector3.up);
            transform.rotation = Quaternion.Slerp (transform.rotation, aimRotation, turnSpeed * Time.deltaTime);			
        }
    }
}
