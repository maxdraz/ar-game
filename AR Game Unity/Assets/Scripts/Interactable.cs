using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public GameObject myObj;

    private void Start()
    {
        myObj = gameObject;
        GameManager.the.AddToObjectToChange(1);
    }

    public virtual void Interaction()
    {
        myObj.SetActive(false);
    }
}
