using UnityEngine;

public class RespawnSystem : MonoBehaviour
{
    public RespawnSignal[] players;

    [ContextMenu("Setup")]
    void Setup()
    {
        players = FindObjectsOfType<RespawnSignal>();
    }

    void Update()
    {
        for (int i = 0; i < players.Length; i++)
        {
            var player = players[i];
            if (player.isReadyToSpawn)
            {
                player.isReadyToSpawn = false;
                player.transform.position = transform.position;
            }
        }
    }

}