using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hide : MonoBehaviour
{
    public GameObject 休息面板;
    public GameObject 強化面板;
    public GameObject 約會面板;
    public GameObject 裝備面板;
    public GameObject 整備UI;

    void Start()
    {

    }

    public void 裝備()
    {
        裝備面板.gameObject.SetActive(true);
        整備UI.gameObject.SetActive(false);
    }
    void Update()
    {

    }

}

