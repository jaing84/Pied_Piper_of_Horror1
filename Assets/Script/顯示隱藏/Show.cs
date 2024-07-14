using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Show : MonoBehaviour
{
    public GameObject show;
    public GameObject show1;
    public GameObject show2;
    public GameObject show3;
    public GameObject show4;
    public GameObject show5;
    public GameObject show6;    
    public GameObject show7;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void 顯示() 
    {
       show.SetActive(true);
    }
    public void 隱藏()
    {
        show.SetActive(false);
    }
    public void 顯示1()
    {
        show1.SetActive(true);
    }
    public void 隱藏1()
    {
        show1.SetActive(false);
    }
    public void 顯示2()
    {
        show2.SetActive(true);
    }
    public void 隱藏2()
    {
        show2.SetActive(false);
    }
    public void 顯示3()
    {
        show3.SetActive(true);
        show5.SetActive(true);
    }
    public void 隱藏3()
    {
        show3.SetActive(false);
        show5.SetActive(false);
    }
    public void 顯示4()
    {
        show4.SetActive(true);
    }
    public void 隱藏4()
    {
        show4.SetActive(false);
    }
    public void 返回鍵()
    {
 
            if (show3 != null && show3.activeSelf)
            {
                show3.SetActive(false);
                show5.SetActive(false);
        }
            else if (show2 != null && show2.activeSelf)
            {
                show2.SetActive(false);
            }

            else if (show1 != null && show1.activeSelf)
            {
                show1.SetActive(false);
            }
        
    }
    // Update is called once per frame
    void Update()
    {
        if (!show6.activeSelf)

        {

            if (show != null)
            {
                if (Input.GetMouseButtonDown(1))
                {

                    show.SetActive(false);
                }
            }
            if (show4 != null)
            {
                if (Input.GetMouseButtonDown(1))
                {

                    show4.SetActive(false);
                }
            }
            if (Input.GetMouseButtonDown(1))
            {
                if (show3 != null && show3.activeSelf)
                {
                    show3.SetActive(false);
                    show5.SetActive(false);
                }
                else if (show2 != null && show2.activeSelf)
                {
                    show2.SetActive(false);
                }

                else if (show1 != null && show1.activeSelf)
                {
                    show1.SetActive(false);
                }
            }
        }
        if (show6 != null)
        {
            if (Input.GetMouseButtonDown(1))
            {

                show6.SetActive(false);
                show7.SetActive(false);
            }
        }
    }
}
