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
    public Transform floor;
    public HouseFuelShow fuelEnergy;

    public List<GameObject> wheels;

    public Rigidbody houseRigidBody;

    public int playerAmount;

    private void FixedUpdate()
    {
        if (isMoving)
        {
            houseRigidBody.velocity = new Vector3(speed, houseRigidBody.velocity.y, 0f);

            foreach (var wheel in wheels)
            {

                wheel.gameObject.transform.Rotate(Vector3.forward, 100 * Time.deltaTime);

            }
        }
        else {
            houseRigidBody.velocity = new Vector3(0, houseRigidBody.velocity.y, 0);
        }
        
    }

    // Start is called before the first frame update
    void Start()
    {
        //this.tt("movewheels").Loop((ttHandler handler)=> {

        //    foreach (var wheel in wheels) {

        //        wheel.gameObject.transform.Rotate(Vector3.left, 100 * Time.deltaTime);

        //    }

        //}).Pause();

        MoveRoutine();
        
        houseCamera.enabled = false;

        outsideDoorTrigger.OnEnter += (Collider collider) => {

            var player = collider.gameObject.GetComponent<PlayerController>();

            if (player != null)
            {
                player.transform.position = insideSpawnPoint.position;
                player.rBodyParent = this.houseRigidBody;
                
                playerAmount++;

                changeCamera();
            }

        };

        insideDoorTrigger.OnEnter += (Collider collider) => {

            var player = collider.gameObject.GetComponent<PlayerController>();

            if (player != null)
            {
                player.transform.position = outsideSpawnPoint.position;
                player.rBodyParent = null;
                playerAmount--;

                changeCamera();
            }

        };
    }

    void MoveRoutine() {

        this.tt().Add(1, (ttHandler handler) => {

            print("playerAmount");
            print(playerAmount);

            if (playerAmount > 0)
            {

                if (fuel > 10)
                {
                    fuel -= 10;

                    if (!isMoving && fuel > 10)
                    {
                        print("comenzando movimiento");
                        isMoving = true;
                    }

                    if (fuel <= 9)
                    {
                        isMoving = false;
                    }

                }

                fuelEnergy.inputFuelValue = fuel;

            }
            else {
                isMoving = false;
            }

            
        }).Repeat();

    }

    void changeCamera() {
        print("player amount " + playerAmount);

        if (playerAmount > 0)
        {
            houseCamera.enabled = true;
            //mainCamera.enabled = false;
            //houseRoof.SetActive(false);
        }
        else
        {
            mainCamera.enabled = true;
            //houseCamera.enabled = false;
            //houseRoof.SetActive(true);
        }
    }
}
