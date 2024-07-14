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
        // 在 Start 方法中初始化 healthText
      //  healthText = GetComponent<Text>();

        if (healthText == null)
        {
            Debug.LogError("Text component not found on the object!");
        }

    }

    public void RestoreHealth(int amount)
    {
        health += amount;
        health = Mathf.Min(health, maxHealth); // 確保健康值不超過最大值
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            // 檢查血量是否大於 0，以確保不會扣除超過最小值的血量
            if (health > 0)
            {
                // 扣除血量
                health -= damageAmount;

                // 確保血量不會小於 0
                health = Mathf.Max(health, 0);
            }
        }

        if (maxHealth > 0)
        {
            // 設置 rectTransform 的 scale
            float newScaleX = health / maxHealth;
            Vector3 newScale = rectTransform.localScale;
            newScale.x = newScaleX;
            rectTransform.localScale = newScale;
        }

        // 更新 UI 文本
        healthText.text = health + "/" + maxHealth;
        healthText2.text = health + "/" + maxHealth;

        
    }
}
