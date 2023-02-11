using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    private static List<Wall> walls = new();

    private Collider2D[] colliders;

    private void Start()
    {
        walls.Add(this);
        colliders = GetComponentsInChildren<Collider2D>();
    }

    public static void OnMaskSpawn(Vector3 maskPos)
    {
        foreach (var w in walls)
        {
            foreach (var col in w.colliders)
            {
                float distanceToMask = (col.transform.position - maskPos).sqrMagnitude;

                if (distanceToMask < TouchErase.SqrMaskRadius)
                    col.enabled = false;
            }
        }
    }
}