using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : Interactable
{
    public override void Interaction()
    {
        base.Interaction();
    }

    private void OnMouseDown()
    {
        Interaction();
        print("clicked");
    }
}
