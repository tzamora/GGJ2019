using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class VehicleBH : MonoBehaviour
{
    [Header("Settings")]
    public float moveDuration = 1;
    public float distanceBetweenPoints = 10;
    public Transform [] waypoints;

    [Header("Data")]
    public Rigidbody rbody;

    [Header("Data")]
    public bool isMoving;
    public float resources = 100;

    private int currentWaypoint;
    private bool paused;

    private void Start ()
    {
        MoveNextWaypoint();
    }

    private void Update ()
    {
        if((transform.position - waypoints[currentWaypoint].position).sqrMagnitude <= (distanceBetweenPoints * distanceBetweenPoints))
        {
            MoveNextWaypoint();
        }

        if(resources < 80)
        {
            transform.DOPause();
            paused = true;
        }
        else if(paused)
        {
            transform.DOPlay();
            paused = false;
        }
    }

    private void MoveNextWaypoint ()
    {
        if(currentWaypoint < waypoints.Length - 1)
        {
            currentWaypoint++;
            isMoving = true;
            transform.DOMove(waypoints[currentWaypoint].position, moveDuration);
        }
        else
        {
            isMoving = false;
        }
    }
}
