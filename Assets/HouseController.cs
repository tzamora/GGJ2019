using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using matnesis.TeaTime;

public class HouseController : MonoBehaviour
{
    public Camera mainCamera;
    public Camera houseCamera;
    public TriggerController outsideDoorTrigger;
    public TriggerController insideDoorTrigger;
    public Transform insideSpawnPoint;
    public Transform outsideSpawnPoint;
    public GameObject houseRoof;
    public float speed = 75;
    public int fuel = 100;
    public bool isMoving = false;

    public Rigidbody houseRigidBody;

    public int playerAmount;

    private void FixedUpdate()
    {
        print("avanzando");
        if (isMoving)
        {
            houseRigidBody.velocity = new Vector3(0, houseRigidBody.velocity.y, speed);
        }
        else {
            houseRigidBody.velocity = Vector3.zero;
        }
        
    }

    // Start is called before the first frame update
    void Start()
    {
        MoveRoutine();
        
        houseCamera.enabled = false;

        outsideDoorTrigger.OnEnter += (Collider collider) => {

            var player = collider.gameObject.GetComponent<PlayerController>();

            if (player != null)
            {
                player.transform.SetParent(transform);
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
                player.transform.SetParent(null);
                playerAmount--;

                changeCamera();
            }

        };
    }

    void MoveRoutine() {

        this.tt().Add(1, (ttHandler handler) => {

            if (playerAmount > 0) {

                if (fuel > 10)
                {
                    fuel -= 10;

                    if (!isMoving && fuel > 10)
                    {
                        isMoving = true;
                    }
                    
                    if(fuel <= 9)
                    {
                        print("deteniendo");
                        isMoving = false;
                    }

                }

            }

            
        }).Repeat();

    }

    void changeCamera() {
        print("player amount " + playerAmount);

        if (playerAmount > 0)
        {
            houseCamera.enabled = true;
            //mainCamera.enabled = false;
            houseRoof.SetActive(false);
        }
        else
        {
            mainCamera.enabled = true;
            //houseCamera.enabled = false;
            houseRoof.SetActive(true);
        }
    }
}
