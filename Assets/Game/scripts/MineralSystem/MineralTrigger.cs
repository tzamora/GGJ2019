using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineralTrigger : MonoBehaviour
{
    public List<Collider> colliders;

    void OnTriggerEnter(Collider other)
    {
        // Only players
        var player = other.GetComponent<PlayerController>();
        if (!player) return;

        colliders.Add(other);
    }
}