using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    public Transform camera;

    private void Awake()
    {
        if (GameObject.FindWithTag("MainCamera") != null)
        {
            camera = GameObject.FindWithTag("MainCamera").transform;
        }
    }
    // Update is called once per frame
    void Update()
    {
        transform.LookAt(camera);
    }
}
