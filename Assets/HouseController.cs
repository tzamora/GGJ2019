using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseController : MonoBehaviour
{
    public Camera mainCamera;
    public Camera houseCamera;
    public TriggerController outsideDoorTrigger;
    public TriggerController insideDoorTrigger;
    public Transform insideSpawnPoint;
    public Transform outsideSpawnPoint;

    public int playerAmount;

    // Start is called before the first frame update
    void Start()
    {
        houseCamera.enabled = false;

        outsideDoorTrigger.OnEnter += (Collider collider) => {

            var player = collider.gameObject.GetComponent<PlayerController>();

            if (player != null)
            {
                player.transform.position = insideSpawnPoint.position;

                playerAmount++;

                changeCamera();
            }

        };

        insideDoorTrigger.OnEnter += (Collider collider) => {

            var player = collider.gameObject.GetComponent<PlayerController>();

            if (player != null)
            {
                player.transform.position = outsideSpawnPoint.position;

                playerAmount--;

                changeCamera();
            }

        };
    }

    void changeCamera() {
        if (playerAmount >= 2)
        {
            houseCamera.enabled = true;
            mainCamera.enabled = false;
        }
        else {
            mainCamera.enabled = true;
            houseCamera.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
