using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : Interactable
{
    public override void Interaction()
    {
        myObj.SetActive(false);
        
    }

    private void OnMouseDown()
    {
        Interaction();
        print("clicked");
    }
}
