using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageController : MonoBehaviour
{
    public TriggerController bodyCollider;

    // Start is called before the first frame update
    void Start()
    {
        bodyCollider.OnEnter += (Collider collider) =>
        {
            var player = bodyCollider.gameObject.GetComponent<PlayerController>();
            if (player)
            {
                player.KillPlayerRoutine();
            }
        };
    }
}
