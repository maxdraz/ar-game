using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenUp : MonoBehaviour
{
    public GameObject turnInto;
    public int points;
    public GameObject pointsTextPrefab;

    private void Start()
    {
        GameManager.the.AddToObjectToChange(points);
    }

    private void OnMouseDown()
    {
        GameManager.the.SubtractToObjectToChange(points);
        if (turnInto)
        {
            turnInto.SetActive(true);
        }
        //instantiate points over object
        Vector3 spawnPos = new Vector3(transform.position.x, 0.01f, transform.position.z);
        GameObject pointsGO = (GameObject)Instantiate(pointsTextPrefab, spawnPos, Quaternion.identity);
        pointsGO.GetComponentInChildren<TextMesh>().text = "+ " + points;

        gameObject.SetActive(false);
    }
}
