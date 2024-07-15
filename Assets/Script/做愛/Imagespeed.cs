using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Imagespeed : MonoBehaviour
{
    public RectTransform image2;
    public float speed;
    public float numble1 = 1.7f;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        測試();
    }
    public void 測試() 
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow) ||
               Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
        {

            numble1 = 1.7f;
        }
        else
        {

            if (numble1 >= 0.9)
            {
                numble1 -= 0.1f * Time.deltaTime * speed;
            }
            else
            {
                numble1 = 1.7f;
            }
        }
        Shrink();

    }
    public void Shrink()
    {

        image2.localScale = new Vector3(numble1, numble1, 1f);
        Vector3 newScale2 = image2.localScale;

    }


    public float Numble1
    {
        get { return numble1; }
    }
}

