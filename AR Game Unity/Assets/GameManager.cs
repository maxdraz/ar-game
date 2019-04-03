using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

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
    private int maxObjects;
    [SerializeField] private TextMeshProUGUI objectsLeft;
    [SerializeField] private GameObject intro;
    [SerializeField] private GameObject outro;
    private enum gameState { start, game, end };
    gameState currentGameState = gameState.start;



    private void Update()
    {
        if (currentGameState == gameState.start)
        {
            if (Input.touchCount > 0)
            {
                Destroy(intro, 0.05f);
                currentGameState = gameState.game;
            }
        }
        else if (currentGameState == gameState.end)
        {
            if (Input.touchCount > 0)
            {
                SceneManager.LoadScene(0);
            }
        }
    }
    
    

    public void AddToObjectToChange(int points)
    {
        ObjectsToChange+=points;
        maxObjects = ObjectsToChange;
        objectsLeft.text = ObjectsToChange.ToString() + "/" + maxObjects.ToString();
        
    }

    public void SubtractToObjectToChange(int points)
    {
        ObjectsToChange-= points;
        objectsLeft.text = ObjectsToChange.ToString() + "/" + maxObjects.ToString();

        if (ObjectsToChange <= 0)
        {
            outro.SetActive(true);
            currentGameState = gameState.end;
        }
    }

   
}
