using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public Rigidbody bodyRigidbody;

    public TriggerController bodyCollider;

    private void Start()
    {
        bodyCollider.OnCollision = (Collision collision) =>
        {
            var player = collision.gameObject.GetComponent<PlayerController>();

            if (player != null)
            {
                player.KillPlayerRoutine();
                Destroy(gameObject);
            }

        };
    }
}
