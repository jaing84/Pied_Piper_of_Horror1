using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleport : MonoBehaviour
{
    public string scenefrom;
    public string sceneToGO;
    public GameObject 目錄;




    public void TeleportToScene()
    {
        Time.timeScale = 1;

        TransitionManager.Instance.Transition(scenefrom, sceneToGO);
        if (目錄.activeSelf)
        {
            目錄.SetActive(false);
        }

    }

}

