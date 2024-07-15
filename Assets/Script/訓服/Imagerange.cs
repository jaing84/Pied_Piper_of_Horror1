using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Imagerange : MonoBehaviour
{
    public RectTransform image1;
    public RectTransform image2;
    public float speed;
    public float numble = 1.7f;
    public float numble1 = 1.7f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) ||
             Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
        {

            numble = 1.7f;
        }
        else
        {

            if (numble >= 0.9)
            {
                numble -= 0.1f * Time.deltaTime * speed;
            }
            else
            {
                numble = 1.7f;
            }
        }


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
        image1.localScale = new Vector3(numble, numble, 1f);
        Vector3 newScale = image1.localScale;

        image2.localScale = new Vector3(numble1, numble1, 1f);
        Vector3 newScale2 = image2.localScale;


    }

    public float Numble
    {
        get { return numble; }
    }
    public float Numble1
    {
        get { return numble1; }
    }
}

