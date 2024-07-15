using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscButton : MonoBehaviour
{
    public GameObject EscMenu;
    

    void Update()
    {
        if (Input.GetButtonDown("ESC"))
            Esc();
    }

    public void Esc()
    {
        if (EscMenu.activeSelf)  

        {
           
            EscMenu.SetActive(false);
            Time.timeScale = 1;
        }
        else 
        {   
            EscMenu.SetActive(true);
            Time.timeScale = 0;
        }

    }
    public void QuitGame()
    {
        Application.Quit();
    }
}

