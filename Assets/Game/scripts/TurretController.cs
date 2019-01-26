using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using matnesis.TeaTime;

public class TurretController : MonoBehaviour
{
    public TriggerController bodyCollider;

    public GameObject bulletPrefab;

    public AudioClip shootSound;

    public int power;
    
    void Start()
    {
        ShootRoutine();
    }

    void Update()
    {
        
    }

    void ShootRoutine()
    {
        this.tt().Add(0.3f, (ttHandler handler) => {

            if (bodyCollider.isColliding)
            {

                foreach (var collider in bodyCollider.others)
                {
                    if (collider == null)
                    {
                        continue;
                    }

                    var player = collider.GetComponent<PlayerController>();

                    if (player != null) {

                        var bullet = GameObject.Instantiate(bulletPrefab, this.transform.position, Quaternion.identity);

                        BulletController bulletInstance = bullet.GetComponent<BulletController>();

                        var heading = (collider.transform.position - bullet.transform.position).normalized;

                        bulletInstance.bodyRigidbody.velocity = heading * power;

                        SoundManager.Get.PlayClip(shootSound, false);
                    }
                    
                }
            }
        }).Repeat();
    }
}
