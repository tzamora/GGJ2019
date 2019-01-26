using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRoom : MonoBehaviour
{
    public int playerIndex;
    public VehicleBH vehicle;

    // dividve speed by player ammount 
    // if one speed is 1/4 or 1/3
    // if four speed is 4/4

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController controller = other.GetComponentInParent<PlayerController>();
            Debug.Log(controller);
            if (controller && controller.playerIndex != playerIndex)
            {
                controller.PushBack();
            }
            else
            {
                if (vehicle != null) vehicle.amountPlayersInside++;
            }
        }
    }

    private void OnTriggerExit (Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController controller = other.GetComponentInParent<PlayerController>();
            if (controller && controller.playerIndex == playerIndex)
            {
                if (vehicle != null) vehicle.amountPlayersInside--;
            }
        }
    }
}
