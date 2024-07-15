using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float health = 50.0f;
    public float maxHealth = 40.0f;
    public float damageAmount = 10.0f;
    public RectTransform rectTransform;

    public Text healthText;
    public Text healthText2;


    private void Start()
    {
        // ??Start ?寞?銝剖?憪? healthText
      //  healthText = GetComponent<Text>();

        if (healthText == null)
        {
            Debug.LogError("Text component not found on the object!");
        }

    }

    public void RestoreHealth(int amount)
    {
        health += amount;
        health = Mathf.Min(health, maxHealth); // 蝣箔??亙熒?潔?頞??憭批?
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            // 瑼Ｘ銵??血之??0嚗誑蝣箔?銝???頞??撠潛?銵??
            if (health > 0)
            {
                // ??銵??
                health -= damageAmount;

                // 蝣箔?銵??????0
                health = Mathf.Max(health, 0);
            }
        }

        if (maxHealth > 0)
        {
            // 閮剔蔭 rectTransform ??scale
            float newScaleX = health / maxHealth;
            Vector3 newScale = rectTransform.localScale;
            newScale.x = newScaleX;
            rectTransform.localScale = newScale;
        }

        // ?湔 UI ?
        healthText.text = health + "/" + maxHealth;
        healthText2.text = health + "/" + maxHealth;

        
    }
}

