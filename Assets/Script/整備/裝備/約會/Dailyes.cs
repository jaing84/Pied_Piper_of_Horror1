using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dailyes : MonoBehaviour
{
    public GameObject play1;
    public GameObject play2;
    public GameObject play3;
    public Sprite image1;
    public Sprite image2;


    public void change()
    {
        Image play1Image = play1.GetComponent<Image>();
        Image play2Image = play2.GetComponent<Image>();
        Image play3Image = play3.GetComponent<Image>();

        if (play1Image.sprite == image1)
        {
            play1Image.sprite = image2;
        }
        else if (play1Image.sprite == image2)
        {
            if (play2Image.sprite == image1)
            {
                play2Image.sprite = image2;
            }
            else if (play2Image.sprite == image2)
            {
                if (play3Image.sprite == image1)
                {
                    play3Image.sprite = image2;
                }
            }
        }
    }
}

