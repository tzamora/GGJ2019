using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using matnesis.TeaTime;

public class TurretController : MonoBehaviour
{
    public TriggerController bodyCollider;

    public GameObject bulletPrefab;

    public int power;
    
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void ShootRoutine()
    {
        this.tt().Loop((ttHandler handler) => {

            if (bodyCollider.isColliding)
            {
                var colliders =
                    bodyCollider.others.OrderBy(item => Vector3.Distance(this.transform.position, item.transform.position)).ToList();

                var target = colliders.First();

                if (target)
                {
                    var heading = target.transform.position - transform.position;

                    var bullet = GameObject.Instantiate(bulletPrefab, this.transform.position, Quaternion.identity);

                    BulletController bulletInstance = bullet.GetComponent<BulletController>();

                    bulletInstance.shoot(heading);
                }
            }

            handler.Wait(1000);

        });
    }
}
