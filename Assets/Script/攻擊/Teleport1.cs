using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport1 : MonoBehaviour
{
    public string scenefrom;
    public string sceneToGO;
    public GameObject 目錄;
    public GameObject 功能Panel1;
    public GameObject 功能Panel2;
    public GameObject 功能Panel3;




    public void TeleportToScene()
    {
        Time.timeScale = 1;
        功能Panel1.SetActive(false);
        功能Panel2.SetActive(false);
        功能Panel3.SetActive(false);

        TransitionManager.Instance.Transition(scenefrom, sceneToGO);
        if (目錄.activeSelf)
        {
            目錄.SetActive(false);
        }
    }
}

