using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using matnesis.TeaTime;

public class TurretController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void SeekAndDestroyRoutine()
    {
        this.tt("SeekAndDestroyRoutine").Loop((ttHandler handler) => {

            // get the player position
            //Vector2 targetPosition = GameContext.Get.player.transform.position;

            //transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * 1);

        });
    }
}
