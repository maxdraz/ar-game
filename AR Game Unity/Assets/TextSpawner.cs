using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextSpawner : MonoBehaviour
{
    public static TextSpawner instance;
    public GameObject pointsTextPrefab;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SpawnText(int points)
    {        
            GameObject pointsGO = (GameObject)Instantiate(pointsTextPrefab, transform.position, transform.rotation);
        pointsGO.transform.SetParent(transform);
        pointsGO.GetComponentInChildren<Text>().text = "- " + points;           
        
    }
}
