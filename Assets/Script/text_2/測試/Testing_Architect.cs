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
            "�ڬO�ӭ�",
            "�n�ӥ�����",
            "�ګܬݦn�p",
            "�ڥi�H���p����",
            "�ڭn���z�p"
        };
            
        
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
                architect.Stop();
            
           
            string longLine = "�o�O�@���ܪ����u�A�@�L�N�q�A�]���ڥu�O�b�̭��뺡�F��A�]���A�A���D�A�F��ܦn�A��a�H�ڳ��w�F��A�A�]���w�F��A�ڭ̳����w�F��A�ҥH���ھާa!";
            if (Input.GetKeyDown(KeyCode.Space))
            {
                
                if(architect.isBuilding)
                {
                    if(!architect.hurryUp)
                        architect.hurryUp = true;
                    else
                        architect.ForceComplete();

                }
                else
                    architect.Build(longLine);
                //architect.Build(lines[Random.Range(0, lines.Length)]);
            }
            else if(Input.GetKeyDown(KeyCode.A))
            {
                architect.Append(longLine);
               // architect.Append(lines[Random.Range(0, lines.Length)]);
            }
        }
        public void TextSpeed()
        {
            Image play11Image = play11.GetComponent<Image>();
            play11Image.sprite = image12;
            if (!architect.hurryUp)
                architect.hurryUp = true;
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
        }

    }
}
