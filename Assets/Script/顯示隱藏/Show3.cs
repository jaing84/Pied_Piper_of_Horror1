using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Show3 : MonoBehaviour
{
    public GameObject show;
    public void 顯示()
    {
        show.SetActive(true);
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

