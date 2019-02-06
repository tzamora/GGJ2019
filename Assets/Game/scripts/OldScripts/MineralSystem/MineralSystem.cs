using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineralSystem : MonoBehaviour
{
    public float harvestedAmount;
    public MineralTrigger[] minerals;

    [ContextMenu("Setup")]
    public void Setup()
    {
        minerals = FindObjectsOfType<MineralTrigger>();
    }

    void Update()
    {
        for (int i = 0; i < minerals.Length; i++)
        {
            var mineral = minerals[i];
            if (mineral.colliders.Count > 0)
            {
                harvestedAmount += 1;

                mineral.transform.parent.transform.position = new Vector3(999, 999, 999);
                mineral.colliders.Clear();
            }
        }
    }
}