using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using matnesis.TeaTime;

public class EnemyController : MonoBehaviour
{
    private Vector3 direction;
    private float aimAngle;
    private Quaternion aimRotation;

    public GameObject body;
    public float walkSpeed = 2;
    public float runSpeed = 3;
    public float turnSpeed = 50;
    private float speedModifier;
    public Rigidbody rbody;
    private Camera mainCam;
    private Vector3 cameraFoward;
    private float horizontal, vertical;

    public TriggerController sensorTrigger;

    private void Start()
    {
        WanderingRoutine();
    }

    private void Update()
    {
        speedModifier = runSpeed;
    }

    private void FixedUpdate()
    {
        direction.x = horizontal;
        direction.z = vertical;

        // Follow camera forward axis as base direction
        //if (mainCam != null)
        //{
        //    print("este codigo nunca se llama");
        //    cameraFoward = Vector3.Scale(mainCam.transform.forward, new Vector3(1, 0, 1)).normalized;
        //    direction = direction.z * cameraFoward + direction.x * mainCam.transform.right;
        //}

        // If moving
        if (direction.x != 0 || direction.z != 0)
        {
            // Rotate character
            aimAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            aimRotation = Quaternion.AngleAxis(aimAngle, Vector3.up);
            body.transform.rotation = Quaternion.Slerp(body.transform.rotation, aimRotation, turnSpeed * Time.deltaTime);
        }

        direction *= speedModifier;
        direction.y = rbody.velocity.y;

        print(direction);

        rbody.velocity = direction;
    }

    void WanderingRoutine()
    {
        //
        // wander around space
        //

        this.tt("WanderingRoutine").Add(2, () =>
        {

            horizontal = 0;
            vertical = 1;

        }).Add(2, () =>
        {
            horizontal = -1;
            vertical = Random.Range(-1f, 1f);

        }).Add(Random.Range(0f, 3f), () =>
        {

            horizontal = 0;
            vertical = -1;

        }).Add(2, () =>
        {

            horizontal = Random.Range(-1f, 1f);
            vertical = 0;

        }).Repeat();

    }

    void SeekAndDestroy()
    {

    }

    void AttackRoutine() {
        
    }
}
