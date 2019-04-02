using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{

    public List<Turret> targets;
    public Transform target;

    [SerializeField] private float speed = 0.5f;
    [SerializeField] private float magnitude = 0.4f;
    


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
                    continue;
                }
            }
        }

        //foreach(Turret target in targets)
        //{
        //    if(target == transform)
        //    {
        //        targets.Remove(target);
        //    }
        //}
    }

    // Update is called once per frame
    void Update()
    {   

        if(target != null)
        {
            ShootTarget(target);
        }
        else
        {
            ChooseTarget();
        }
        //sinewave        
        Levitate();
     
        
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
        //transform.LookAt(target);

        //lerp way
        //need rot speed
        Vector3 toTarget = target.position - transform.position;
        //transform.Rotate()
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(toTarget), Time.deltaTime);
    }

    void Levitate()
    {
        //make it happen no matter y 
        // make it relative to parent's up
        Vector3 pos = transform.position;
        float newY = Mathf.Sin(Time.time * speed);
        
        transform.localPosition = new Vector3(0, newY, 0) * magnitude;
       
              
    }
}
