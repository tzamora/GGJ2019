using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class PlayerActor : MonoBehaviour
{
    [Header ("Settings")]
    public string playerName;
    public int playerIndex;
    public float pushBackPower = 250;

    [Header ("References")]
    public Rigidbody rbody;
    public PlayerMovement playerMovement;

    private Player playerRewired;

    [Header ("Data")]
    private Vector3 movement;
    
    
    private void Start()
    {
        // Get player controls
        playerRewired = ReInput.players.GetPlayer(playerIndex);

        // Pass it to other components
        playerMovement.SetInput(playerRewired);
    }

    private void FixedUpdate()
    {
        // Move player
        movement = playerMovement.GetDirection();
        movement.y = rbody.velocity.y;
        rbody.velocity = movement;        
    }
}
