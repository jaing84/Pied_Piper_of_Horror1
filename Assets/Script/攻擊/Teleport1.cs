using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport1 : MonoBehaviour
{
    public string scenefrom;
    public string sceneToGO;
    public GameObject �ؿ�;
    public GameObject �\��Panel1;
    public GameObject �\��Panel2;
    public GameObject �\��Panel3;




    public void TeleportToScene()
    {
        Time.timeScale = 1;
        �\��Panel1.SetActive(false);
        �\��Panel2.SetActive(false);
        �\��Panel3.SetActive(false);

        TransitionManager.Instance.Transition(scenefrom, sceneToGO);
        if (�ؿ�.activeSelf)
        {
            �ؿ�.SetActive(false);
        }
    }
}
