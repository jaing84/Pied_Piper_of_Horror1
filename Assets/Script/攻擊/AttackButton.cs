using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackButton : MonoBehaviour
{
  
    public GameObject buttonset1;
  



    public void butoone1()
    {
  
        buttonset1.SetActive(true);
    
    }


    public void CloseAllButtonSets()
    {
        if (buttonset1 != null)
            buttonset1.SetActive(false);
        return;
    }



}
