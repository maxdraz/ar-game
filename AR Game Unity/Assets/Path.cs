using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Path : MonoBehaviour
{
    public List<Transform> pathPoints = new List<Transform>();

    private void Start()
    {
        foreach(Transform child in transform)
        {
            pathPoints.Add(child);
        }
    }

    private void OnDrawGizmos()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Gizmos.color = Color.blue;
            if (i != transform.childCount - 1)
            {
                Gizmos.DrawLine(transform.GetChild(i).position, transform.GetChild(i+ 1).position);
            }
            else
            {
                Gizmos.DrawLine(transform.GetChild(i).position, transform.GetChild(0).position);
            }
        }
    }
}
