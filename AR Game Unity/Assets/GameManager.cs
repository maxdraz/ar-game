using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager the = null;
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
