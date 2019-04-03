using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetInactiveAfterTime : MonoBehaviour
{
   
   public float time;

    private void OnEnable()
    {
        StartCoroutine(SetInactive(time));
    }


    IEnumerator SetInactive(float t)
    {
        yield return new WaitForSeconds(t);
        gameObject.SetActive(false);
        this.enabled = false;

       
    }
}
