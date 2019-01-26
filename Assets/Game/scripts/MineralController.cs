using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineralController : MonoBehaviour
{
    [Header("Settings")]
    public int amount;

    public TriggerController bodyCollider;

    // Start is called before the first frame update
    void Update()
    {
        if (bodyCollider.isColliding) {

            print("entrando");

            var player = bodyCollider.gameObject.GetComponent<PlayerController>();

            print(player);
            
            if (player && player.gamePlayerInput.actions.attack.WasPressed) {
                print("botonazo");
                player.Recolect(amount);
                Destroy(gameObject);
            }
        }
    }
}
