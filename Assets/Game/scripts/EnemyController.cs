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
    public Vector3 playerDirection;


    public TriggerController sensorTrigger;

    private void Start()
    {
        WanderingRoutine();

        sensorTrigger.OnExit += (Collider collider) => {

            this.tt("WanderingRoutine").Play();
        }; 

    }

    private void Update()
    {
        speedModifier = runSpeed;
    }

    private void FixedUpdate()
    {

        if (sensorTrigger.isColliding) {

            foreach (var collider in sensorTrigger.others) {

                if (collider != null) {

                    var player = collider.gameObject.GetComponent<PlayerController>();

                    if (player != null)
                    {
                        playerDirection = (player.transform.position - transform.position).normalized;

                        this.tt("WanderingRoutine").Pause();
                        
                        horizontal = playerDirection.x;

                        vertical = playerDirection.z;
                    }

                }

            }

        }
        
        direction.x = horizontal;
        direction.z = vertical;

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

    void FollowPlayerRoutine()
    {
        
    }

    void AttackRoutine() {

        this.tt().Add(3f, (ttHandler handler) => {

            this.tt("WanderingRoutine").Play();

        });
        
    }
}
