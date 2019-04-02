using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    private int ObjectsToChange;
    [SerializeField] private TextMeshProUGUI objectsLeft;

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
