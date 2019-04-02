using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenUp : MonoBehaviour
{
    public GameObject turnInto;

    private void Start()
    {
        GameManager.the.AddToObjectToChange();
    }

    private void OnMouseDown()
    {
        GameManager.the.SubtractToObjectToChange();
        if (turnInto)
        {
            turnInto.SetActive(true);
        }
        gameObject.SetActive(false);
    }
}
