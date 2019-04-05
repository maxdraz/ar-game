using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [System.Serializable]
    public class Menu
    {
        public string name;
        public bool toggledOn;
        public List<GameObject> ObjectsToToggle;
    }

    [SerializeField] private List<Menu> menus;
   

  public void PauseUnpauseGame()
    {
        if (Time.timeScale > 0)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }

    public void ToggleMenu(int menuIndex)
    {    
        Menu menu = menus[menuIndex];

        if (menu.toggledOn)
        {
            foreach (GameObject obj in menu.ObjectsToToggle)
            {
                print("should be set inactive");
                obj.SetActive(false);
            }
            //reverse bool
            menu.toggledOn = false;        
        } else
        {
            foreach (GameObject obj in menu.ObjectsToToggle)
            {
              obj.SetActive(true);
            }
           //reverse bool
            menu.toggledOn = true;
        }
    }

   
}
