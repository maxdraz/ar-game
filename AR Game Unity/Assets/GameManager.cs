using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Android;

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

    [SerializeField] private int ObjectsToChange;
    private int maxObjects;
    [SerializeField] private TextMeshProUGUI objectsLeft;
    [SerializeField] private GameObject intro;
    [SerializeField] private GameObject outro;
    private enum gameState { start, game, end };
    gameState currentGameState = gameState.start;
    public bool end;
    public bool end2;



    private void Update()
    {

        if (ObjectsToChange <= 0 && end == false && end2 == false)
        {
            end = true;



        }

        if (end)
        {
            MenuManager.instance.ToggleMenu(1);
            MenuManager.instance.ToggleMenu(3);
            end = false;
            end2 = true;

           

        }
    }



        public void AddToObjectToChange(int points)
        {
            ObjectsToChange += points;
            maxObjects = ObjectsToChange;
            objectsLeft.text = ObjectsToChange.ToString() + "/" + maxObjects.ToString();

        }

        public void SubtractToObjectToChange(int points)
        {
            ObjectsToChange -= points;
            objectsLeft.text = ObjectsToChange.ToString() + "/" + maxObjects.ToString();

            if (ObjectsToChange <= 0)
            {
                ObjectsToChange = 0;
                outro.SetActive(true);
                currentGameState = gameState.end;
            }
        }

        public void LoadScene(int index)
        {
            SceneManager.LoadScene(index);
        }

    }

