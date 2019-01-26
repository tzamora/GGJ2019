using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineralController : MonoBehaviour
{
    [Header("Settings")]
    public int amount;

    public bool isInside;

    public TriggerController bodyCollider;

    // Start is called before the first frame update
    void Update()
    {
        if (bodyCollider.isColliding && isInside) {

            // isInside = true;
            // print("entrando");

            var player = bodyCollider.gameObject.GetComponent<PlayerController>();
            // no tiene un player controller 
            // print(player);
            
            if (player && player.gamePlayerInput.actions.attack.WasPressed) {
                print("botonazo");
                player.Recolect(amount);
                Destroy(gameObject);
            }
        }
    }
}
