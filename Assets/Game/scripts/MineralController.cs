using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineralController : MonoBehaviour
{
    [Header("Settings")]
    public int amount;

    public AudioClip recolectSound;

    public TriggerController bodyCollider;

    // Start is called before the first frame update
    void Update()
    {
        if (bodyCollider.isColliding) {

            foreach (var collider in bodyCollider.others) {

                var player = collider.gameObject.GetComponent<PlayerController>();
                
                if (player && player.gamePlayerInput.actions.attack.WasPressed)
                {
                    player.Recolect(amount);
                    Destroy(gameObject);
                    SoundManager.Get.PlayClip(recolectSound, false);
                }

            }
        }
    }
}
