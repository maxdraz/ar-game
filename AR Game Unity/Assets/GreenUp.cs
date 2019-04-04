using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class GreenUp : MonoBehaviour
{
    public GameObject turnInto;
    public int points;
    public GameObject pointsTextPrefab;
    public List<AudioClip> sounds;
    private AudioSource audio;

    private void Start()
    {
        audio = GetComponent<AudioSource>();
        audio.clip = sounds[0];
        audio.loop = true;
        audio.Play();
        GameManager.the.AddToObjectToChange(points);
    }

    private void OnMouseDown()
    {
        GameManager.the.SubtractToObjectToChange(points);
        //audio
        audio.clip = sounds[1];
        audio.loop = false;
        audio.Play();
        if (turnInto)
        {
            turnInto.SetActive(true);
        }
        //instantiate points over object
        TextSpawner.instance.SpawnText(points);

        gameObject.SetActive(false);
    }
}
