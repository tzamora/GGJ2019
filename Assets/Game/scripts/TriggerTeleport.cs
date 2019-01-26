using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTeleport : MonoBehaviour
{
    public Transform pointToGo;

    private void OnTriggerEnter (Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController controller = other.GetComponent<PlayerController>();
            if(Vector3.Dot((transform.position - controller.body.transform.position).normalized, controller.body.transform.position) >=0 )
            {
                other.transform.position = pointToGo.position;
            }
        }
    }
}
