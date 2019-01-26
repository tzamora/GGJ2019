using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTeleport : MonoBehaviour
{
    public Transform pointToGo;

    private void OnTriggerEnter (Collider other)
    {
        if(other.CompareTag("Player"))
        {
            other.transform.position = pointToGo.position;
        }
    }
}
