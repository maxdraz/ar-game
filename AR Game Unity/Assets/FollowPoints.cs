using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPoints : MonoBehaviour
{
    [SerializeField] private Path path;
    public int currentPoint;
    [SerializeField] private float speed;
    public Transform pointer;

    private void Start()
    {
        
        pointer.position = path.transform.GetChild(0).position;
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        transform.LookAt(pointer, pointer.up);

        if (Vector3.Distance(transform.position, pointer.position) < 0.1f)
        {
            currentPoint++;
            if (currentPoint == path.pathPoints.Count)
            {
                currentPoint = 0;
            }
            pointer.position = path.pathPoints[currentPoint].position;
        }
    }
}
