using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using matnesis.TeaTime;

public class VehicleBH : MonoBehaviour
{
    [Header("Settings")]
    public float moveDurationFour = 5;
    public float moveDurationThree = 10;
    public float distanceBetweenPoints = 10;
    public Transform [] waypoints;
    public int amountPlayersInside = 4;
    public float reduceResourcesSpeed = 1;

	public AudioClip runningSound;
	public AudioClip idleSound;

	bool soundsA;
	bool soundsB;

    [Header("Data")]
    public Rigidbody rbody;

    [Header("Data")]
    public bool isMoving;
    public float resources = 100;

    private int currentWaypoint, lastAmountPlayers = 4;
    private bool paused;

    private void Start ()
    {
        MoveNextWaypoint();

        this.tt("CheckForPlayers").Add(0.1f, () =>
        {
            if(amountPlayersInside < 3)
            {
                this.tt("@MovingHouse").Stop();
                lastAmountPlayers = amountPlayersInside;
                isMoving = false;
            }
            else
            {
                if(lastAmountPlayers != amountPlayersInside)
                {
                    this.tt("@MovingHouse").Stop();
                    lastAmountPlayers = amountPlayersInside;
                }
                this.tt("@MovingHouse").Play();
                isMoving = true;
            }
        }).Repeat();
    }

    private void Update ()
    {
        if((transform.position - waypoints[currentWaypoint].position).sqrMagnitude <= (distanceBetweenPoints * distanceBetweenPoints))
        {
            MoveNextWaypoint();
        }

        if(isMoving)
        {
            resources -= Time.deltaTime * reduceResourcesSpeed;
            resources = Mathf.Clamp(resources, 0, 100);
        }
        if (resources <= 0) isMoving = false;
        if(!isMoving && resources > 0 && amountPlayersInside > 3)
        {
            this.tt("@MovingHouse").Play();
        }
        //if(resources < 80 || amountPlayersInside < 3)
        //{
        //    transform.DOPause();
        //    paused = true;
        //}
        //else if(paused)
        //{
        //    if(amountPlayersInside == 3) transform.DOMove(waypoints[currentWaypoint].position, moveDurationThree);
        //    else if(amountPlayersInside == 4) transform.DOMove(waypoints[currentWaypoint].position, moveDurationFour);
        //    paused = false;
        //}
    }

    private void MoveNextWaypoint ()
    {
        if(currentWaypoint < waypoints.Length - 1)
        {
            currentWaypoint++;
            isMoving = true;
            this.tt("@MovingHouse").Reset().Loop(() => { return amountPlayersInside == 3 ? moveDurationThree : moveDurationFour; },
            (ttHandler t) => 
            {
                transform.position = Vector3.Lerp(transform.position, waypoints[currentWaypoint].position, t.deltaTime * (resources/100));
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation((transform.position - waypoints[currentWaypoint].position)), t.deltaTime * (resources / 100));
            });
        }
        else
        {
            isMoving = false;
        }
    }
}
