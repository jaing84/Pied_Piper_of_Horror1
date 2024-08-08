using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Show3 : MonoBehaviour
{
    public GameObject show;
    public GameObject show1;
    public GameObject show2;
    public void 顯示()
    {
        if (show1 && show2 == null)
        {
            Debug.Log("1");
            show.SetActive(true);
        }
        else if( show1 != null && show2 != null)
        {
            Debug.Log("2");
            show1.SetActive(false);
            show.SetActive(true);
            show2.SetActive(false);
        }
        else 
        {
            show.SetActive(true);
        }

    }
    public void 隱藏()
    {
        show.SetActive(false);
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

}

