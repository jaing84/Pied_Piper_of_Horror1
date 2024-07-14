using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeralthBar : MonoBehaviour
{
    public Image Bar;
    public float health = 0;
    public float maxHealth = 100;
    private float _lerpSpeed = 3;
    // Update is called once per frame
    void Update()
    {
        BarFiller();
    }
    private void BarFiller() 
    {
        Bar.fillAmount = Mathf.Lerp(Bar.fillAmount,health/maxHealth,_lerpSpeed*Time.deltaTime);
    }
    public void AddHealth() 
    {
        health += 10;
    } 
    public void RedvceHealth() 
    {
       health -= 10;
    }
}
