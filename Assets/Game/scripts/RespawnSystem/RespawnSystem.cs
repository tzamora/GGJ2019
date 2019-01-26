using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnSystem : MonoBehaviour
{
    public RespawnSignal[] players;

    void Update()
    {
        for (int i = 0; i < players.Length; i++)
        {
            var player = players[i];
            if (player.isReadyToSpawn)
            {
                player.isReadyToSpawn = false;
                player.transform.position = Vector3.zero;
            }
        }
    }

}