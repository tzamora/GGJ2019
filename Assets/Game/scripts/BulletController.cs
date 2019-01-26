using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public Rigidbody bodyRigidbody;

    public int power;

    // Start is called before the first frame update
    public void shoot(Vector3 heading) {
        bodyRigidbody.velocity = heading * power;
    }

    void bulletController() {
        
    }
}
