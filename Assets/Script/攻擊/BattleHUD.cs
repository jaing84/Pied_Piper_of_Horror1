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
        int currentHealth = Mathf.Max(pm.目前血量, 0);
        hp1.text = currentHealth.ToString();
        hpSlider.maxValue = pm.最大血量;
        hpSlider.value = currentHealth;
        if (sam1 != null)
        {
            samSlider.maxValue = pm.最大狂氣值;
            samSlider.value = pm.目前狂氣值;
            sam1.text = pm.目前狂氣值.ToString();
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
