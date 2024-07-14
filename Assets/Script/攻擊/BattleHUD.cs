using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleHUD : MonoBehaviour
{
    public Slider hpSlider;
    public Slider samSlider;
    public Text hp1;
    public Text sam1;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetHUD(Pokemon pm)
    {
        int currentHealth = Mathf.Max(pm.�ثe��q, 0);
        hp1.text = currentHealth.ToString();
        hpSlider.maxValue = pm.�̤j��q;
        hpSlider.value = currentHealth;
        if (sam1 != null)
        {
            samSlider.maxValue = pm.�̤j�g���;
            samSlider.value = pm.�ثe�g���;
            sam1.text = pm.�ثe�g���.ToString();
        }

    }

    public void Setup(int hp) 
    {
        hpSlider.value = hp;
       
    }
    public void Setup1(int sam)
    {
            samSlider.value = sam;     
    }

}
