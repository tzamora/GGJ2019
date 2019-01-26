using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRoom : MonoBehaviour
{
    public int playerIndex;

    private void OnTriggerEnter (Collider other)
    {
        if(other.CompareTag("Player"))
        {
            PlayerController controller = other.GetComponentInParent<PlayerController>();
            //if(controller && controller.playerIndex != playerIndex)
            //{
            //    controller.PushBack();
            //}
        }
    }
}
