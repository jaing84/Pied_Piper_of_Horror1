using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.UI;
namespace TESTING
{
    public class Testing_Architect : MonoBehaviour
    {
        public  GameObject play11;
        public Sprite image11;
        public Sprite image12;
        public Sprite image13;
        DialogueSystem ds;
        TextArchitect architect;
        public TextArchitect.BuildMethod bm  = TextArchitect.BuildMethod.instant;
        // Start is called before the first frame update
        string[] lines = new string[5]
        {
            "文本文本文本1",
            "文本文本文本2",
            "文本文本文本3",
            "文本文本文本4",
            "文本文本文本5"
        };
        string[] texts = new string[]
       {
            "晚上好，這位客人，有做個好夢嗎?!",
            "今晚有客人您的大駕光臨，小店蓬蓽生輝、好生感激……",
            "按Esc會出現目錄",
            "只要按右鍵多出來的頁面會消失",
            "文本文本文本文本文本文本",
            "請前往戰鬥場景"
       };

        int currentTextIndex = 0;
        public GameObject buttonline;

        void Start()
        {
            ds = DialogueSystem.instance;
            architect = new TextArchitect(ds.dialogueContainer.dialogueText);
            architect.buildMethod = TextArchitect.BuildMethod.fade;
            architect.speed = 0.5f;
        }

        // Update is called once per frame
        void Update()
        {
            if(bm != architect.buildMethod) 
            {
                architect.buildMethod = bm;
                architect.Stop();
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                architect.Stop();
              
            }
           

            //  string longLine = "這是一條很長的線，毫無意義，因為我只是在裡面塞滿東西，因為，你知道，東西很好，對吧？我喜歡東西，你也喜歡東西，我們都喜歡東西，所以給我操吧!";
            if (Input.GetKeyDown(KeyCode.Space) )
            {
                
                if(architect.isBuilding)
                {
                    if(!architect.hurryUp)
                        architect.hurryUp = true;
                    else
                        architect.ForceComplete();

                }
                else if (currentTextIndex < texts.Length)
                {
                    architect.Build(texts[currentTextIndex]);

                    currentTextIndex++;

                    if (currentTextIndex >= texts.Length)
                    {
                        //currentTextIndex = 0;
                        buttonline.SetActive(true);
                    }
                    //   architect.Build(longLine);
                    //architect.Build(lines[Random.Range(0, lines.Length)]);
                }
            }
            else if(Input.GetKeyDown(KeyCode.A))
            {
                architect.Append(texts[currentTextIndex]);
                // architect.Append(longLine);
                // architect.Append(lines[Random.Range(0, lines.Length)]);
            }
        }
        public void TextSpeed()
        {
            Image play11Image = play11.GetComponent<Image>();
            play11Image.sprite = image12;
            if (!architect.hurryUp)
                architect.hurryUp = true;
            SetSpeed(2.0f);
        }
        public void Text_Exit() 
        {
            Image play11Image = play11.GetComponent<Image>();
            play11Image.sprite = image13;
            architect.ForceComplete();
        }
        public void Nicespeed() 
        {
            Image play11Image = play11.GetComponent<Image>();
            play11Image.sprite = image11;

            if (!architect.hurryUp)
                architect.hurryUp = false;
            SetSpeed(1.0f);
        }
        public void SetSpeed(float speedMultiplier)
        {
            architect.speed = 0.5f / speedMultiplier; 
        }
        public void DoubleSpeed()
        {
            Image play11Image = play11.GetComponent<Image>();
            SetSpeed(0.5f);
            play11Image.sprite = image12;
        }

        public void QuadrupleSpeed()
        {
            Image play11Image = play11.GetComponent<Image>();
            SetSpeed(0.25f);
            play11Image.sprite = image13;
        }

    }
}

