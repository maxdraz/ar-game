﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPoints : MonoBehaviour
{
    [SerializeField] private Path path;
    public int currentPoint;
    [SerializeField] private float speed;
    [SerializeField] private float turnSpeed;
    public Transform pointer;

    public bool loop = true;
    public GameObject objectNonCar;

    private void Start()
    {
        
        pointer.position = path.transform.GetChild(currentPoint).position;
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        

        Vector3 dir = pointer.position - transform.position;
        Quaternion rot = Quaternion.LookRotation(dir, pointer.up);
        // slerp to the desired rotation over time
        transform.rotation = Quaternion.Slerp(transform.rotation, rot, turnSpeed * 2 * Time.deltaTime);
        

        if (Vector3.Distance(transform.position, pointer.position) < 0.3f)
        {
            if (!loop && currentPoint == 0)
            {
                objectNonCar.SetActive(true);
                speed = 2;
            }

            currentPoint++;
            if (currentPoint == path.pathPoints.Count && loop)
            {
                currentPoint = 0;
            }
            else if(currentPoint == path.pathPoints.Count && !loop)
            {
                currentPoint = 0;
                objectNonCar.SetActive(false);
                speed = 0.5f;
            }
            pointer.position = path.pathPoints[currentPoint].position;

            
        }
    }
}
