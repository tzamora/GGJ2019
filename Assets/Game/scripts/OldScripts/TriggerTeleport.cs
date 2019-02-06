using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTeleport : MonoBehaviour
{
    public Transform pointToGo;
    public bool invert;

    private float faceDirection;

    private void OnTriggerEnter (Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController controller = other.GetComponent<PlayerController>();
            faceDirection = Vector3.Dot((transform.position - controller.body.transform.position).normalized, controller.body.transform.position);

            if(invert)
            {
                if (faceDirection > 0)
                {
                    other.transform.position = pointToGo.position;
                    other.transform.SetParent(pointToGo);
                }
                else
                {
                    other.transform.SetParent(null);
                }
            }
            else
            {
                if (faceDirection < 0)
                {
                    other.transform.position = pointToGo.position;
                    other.transform.SetParent(pointToGo);
                }
                else
                {
                    other.transform.SetParent(null);
                }
            }
        }
    }
}
