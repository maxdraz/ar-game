using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager the = null;

    void Awake()
    {
        //Check if instance already exists
        if (the == null)
        { 
            //if not, set instance to this
            the = this;
        }
        //If instance already exists and it's not this:
        else if (the != this)
        { 
            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);
        }

    }

    private int ObjectsToChange;
    [SerializeField] private TextMeshProUGUI objectsLeft;
    [SerializeField] private GameObject intro;

    private void OnMouseDown()
    {
        Destroy(intro, 0.05f);
    }

    public void AddToObjectToChange()
    {
        ObjectsToChange++;
        objectsLeft.text = ObjectsToChange.ToString();
    }

    public void SubtractToObjectToChange()
    {
        ObjectsToChange--;
        objectsLeft.text = ObjectsToChange.ToString();
    }


}
