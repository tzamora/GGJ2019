using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using matnesis.TeaTime;
using InControl;

public class PlayerController : MonoBehaviour
{
    [Header("Settings")]
    public string playerName;

    public GameObject body;

    public float walkSpeed = 2;
    public float runSpeed = 3;
    
    [Header("References")]

    public AudioClip starSound;
    public GamePlayerInput gamePlayerInput;
    public Rigidbody rbody;
    private GameInputActions actions;
    public TriggerController bodyCollider;

    [Header("Data")]
    public bool isRunning;
    private float horizontal, vertical;
    private Vector3 direction;
    private float speedModifier;

    // Start is called before the first frame update
    void Start()
    {
        //GameInputBinding();
        actions = gamePlayerInput.actions;

        bodyCollider.OnEnter += (Collider collider) =>
        {
            var damage = collider.gameObject.GetComponent<DamageController>();
            if (damage)
            {
                KillPlayerRoutine();
            }
        };
    }

    private void Update()
    {

        horizontal = gamePlayerInput.Movement.x;
        vertical = gamePlayerInput.Movement.y;

        speedModifier = isRunning ? runSpeed : walkSpeed;

    }

    private void FixedUpdate()
    {
        direction.x = horizontal;
        direction.z = vertical;

        direction *= speedModifier;
        direction.y = rbody.velocity.y;

        rbody.velocity = direction;
    }

    void SoundsRoutine()
    {
        this.tt().Add(5, (ttHandler handler) => {

            SoundManager.Get.PlayClip(starSound, false);

        }).Repeat();
    }

    public void KillPlayerRoutine() {
        print("player dead");
        Destroy(gameObject);
    }

    public void Recolect(int amount) {
        print("Recolecting " + amount);
    }
}
