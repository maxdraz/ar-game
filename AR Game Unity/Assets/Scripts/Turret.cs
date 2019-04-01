using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{

    public List<Turret> targets;
    public Transform target;

    [SerializeField] private float speed;
    [SerializeField] private float magnitude;
    [SerializeField] private float theta;


    private void Start()
    {
        foreach (Turret t in GameObject.FindObjectsOfType<Turret>())
        {
            if (t != null)
            {
                if (t != this)
                {
                    targets.Add(t);
                }
                else
                {
                    break;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        theta += Time.deltaTime;

        if(target != null)
        {
            ShootTarget(target);
        }
        else
        {
            ChooseTarget();
        }
        //sinewave        
        //Levitate();
     
        
    }

    void ChooseTarget()
    {
        if (targets.Count > 0)
        {
            target = targets[Random.Range(0, targets.Count - 1)].transform;
        }
    }

    void ShootTarget(Transform target)
    {
        transform.LookAt(target);

        //lerp way
        //need rot speed
        //Vector3 toTarget = target.position - transform.position;
        //transform.Rotate()
    }

    void Levitate()
    {
        Vector3 pos = transform.position;
        float newY = Mathf.Sin(Time.time * speed);
        
        transform.position = new Vector3(pos.x, newY, pos.z) * magnitude;
       
              
    }
}
